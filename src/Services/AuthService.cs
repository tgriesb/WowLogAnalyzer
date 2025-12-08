using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Models;
using System.Text;
using System;

namespace WowLogAnalyzer.Services;

public class AuthService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IJwtSecurityService jwtSecurityService, IConfiguration config, IWebHostEnvironment env) : IAuthService
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    private readonly IJwtSecurityService _jwtSecurityService = jwtSecurityService ?? throw new ArgumentNullException(nameof(jwtSecurityService));
    private readonly IConfiguration _config = config ?? throw new ArgumentNullException(nameof(config));
    private readonly IWebHostEnvironment _env = env ?? throw new ArgumentNullException(nameof(env));
    
    public string CreateAccessToken(User user)
    {
        return _jwtSecurityService.GenerateJwtToken(user);
    }

    private (string token, RefreshToken entity) GenerateRefreshToken(UserSession session)
    {
        var rawTokenBytes = RandomNumberGenerator.GetBytes(64);
        var rawToken = Convert.ToBase64String(rawTokenBytes);
        var hash = HashToken(rawToken);

        var lifetimeDays = int.TryParse(_config["Jwt:RefreshTokenDays"], out var d) ? d : 30;
        var expires = DateTime.UtcNow.AddDays(lifetimeDays);

        var entity = new RefreshToken
        {
            UserSessionId = session.Id,
            TokenHash = hash,
            ExpiresAt = expires,
            CreatedByIp = GetIpAddress()
        };

        return (rawToken, entity);
    }
    
    private static string HashToken(string token)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(token);
        var hashBytes = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hashBytes);
    }

    public async Task<LoginDto> LoginAsync(string email, string password, string? deviceName)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new Exception("Invalid credentials");

        // 1) create session for this device/browser
        var session = new UserSession
        {
            UserId = user.Id,
            DeviceName = string.IsNullOrWhiteSpace(deviceName) ? "Browser" : deviceName,
            UserAgent = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString() ?? string.Empty,
            IpAddress = GetIpAddress()
        };

        _dbContext.UserSessions.Add(session);
        await _dbContext.SaveChangesAsync(); // session.Id generated

        // 2) create tokens
        var accessTokenLifetimeMinutes = int.TryParse(_config["Jwt:ExpireMinutes"], out var m) ? m : 15;
        var accessExpires = DateTime.UtcNow.AddMinutes(accessTokenLifetimeMinutes);

        var accessToken = CreateAccessToken(user);

        var (refreshTokenRaw, refreshTokenEntity) = GenerateRefreshToken(session);
        var refreshExpires = refreshTokenEntity.ExpiresAt;

        _dbContext.RefreshTokens.Add(refreshTokenEntity);
        await _dbContext.SaveChangesAsync();

        // 3) set cookies
        SetAuthCookies(accessToken, refreshTokenRaw, accessExpires, refreshExpires);

        // 4) return user profile only (no tokens)
        return new LoginDto
        {
            Id = user.Id,
            Email = user.Email,
            // other fields
        };
    }

    public async Task<LoginDto?> RefreshAsync()
    {
        if (!(_httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue("wla_refresh", out var rawRefreshToken) ?? false) || string.IsNullOrEmpty(rawRefreshToken))
            throw new Exception("Missing refresh token");

        var tokenHash = HashToken(rawRefreshToken);

        var refreshToken = await _dbContext.RefreshTokens
            .Include(rt => rt.UserSession)
            .ThenInclude(s => s.User)
            .FirstOrDefaultAsync(rt => rt.TokenHash == tokenHash);

        if (refreshToken == null || !refreshToken.IsActive)
            throw new Exception("Invalid refresh token");

        // OPTIONAL: detect refresh token reuse
        if (refreshToken.ReplacedByTokenId != null || refreshToken.IsRevoked)
        {
            // suspicious - revoke entire session
            await RevokeSession(refreshToken.UserSession, "Detected refresh token reuse", GetIpAddress());
            await _dbContext.SaveChangesAsync();
            throw new Exception("Invalid refresh token");
        }

        // Rotate: revoke old, create new
        var newTokenPair = GenerateRefreshToken(refreshToken.UserSession);
        var (newRawRefreshToken, newRefreshEntity) = newTokenPair;

        refreshToken.RevokedAt = DateTime.UtcNow;
        refreshToken.RevokedByIp = GetIpAddress();
        refreshToken.RevokedReason = "Rotated";
        refreshToken.ReplacedByToken = newRefreshEntity;

        _dbContext.RefreshTokens.Add(newRefreshEntity);

        // Update session last seen
        refreshToken.UserSession.LastSeenAt = DateTime.UtcNow;

        // New access token
        var user = refreshToken.UserSession.User;
        var accessTokenLifetimeMinutes = int.TryParse(_config["Jwt:ExpireMinutes"], out var m) ? m : 15;
        var accessExpires = DateTime.UtcNow.AddMinutes(accessTokenLifetimeMinutes);
        var accessToken = CreateAccessToken(user);

        await _dbContext.SaveChangesAsync();

        SetAuthCookies(accessToken, newRawRefreshToken, accessExpires, newRefreshEntity.ExpiresAt);

        return new LoginDto
        {
            Id = user.Id,
            Email = user.Email,
        };
    }

    private async Task RevokeSession(UserSession session, string reason, string ip)
    {
        session.RevokedAt = DateTime.UtcNow;
        session.RevokedReason = reason;

        foreach (var token in session.RefreshTokens.Where(t => t.IsActive))
        {
            token.RevokedAt = DateTime.UtcNow;
            token.RevokedByIp = ip;
            token.RevokedReason = reason;
        }

        await Task.CompletedTask;
    }

    public async Task LogoutAsync()
    {
        
        if (!(_httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue("wla_refresh", out var rawRefreshToken) ?? false) || string.IsNullOrEmpty(rawRefreshToken))
        {
            ClearAuthCookies();
            return;
        }

        var hash = HashToken(rawRefreshToken);

        var refreshToken = await _dbContext.RefreshTokens
            .Include(rt => rt.UserSession)
            .FirstOrDefaultAsync(rt => rt.TokenHash == hash);

        if (refreshToken != null && refreshToken.UserSession.IsActive)
        {
            await RevokeSession(refreshToken.UserSession, "User logout", GetIpAddress());
            await _dbContext.SaveChangesAsync();
        }

        ClearAuthCookies();
    }

    public int? GetCurrentUserId()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
            return null;

        var user = httpContext.User;
        if (user?.Identity == null || !user.Identity.IsAuthenticated)
            return null;

        // "sub" matches what you put in your JWT
        var userIdClaim = user.FindFirst("sub")?.Value;
        if (userIdClaim == null)
            return null;

        return int.TryParse(userIdClaim, out var id) ? id : null;
    }

    private string GetIpAddress()
    {
        return _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "unknown";
    }
    
    private void SetAuthCookies(string accessToken, string refreshToken, DateTime accessExpires, DateTime refreshExpires)
    {
        bool secure = _env.IsProduction();

        var accessCookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = secure,
            SameSite = SameSiteMode.Lax,
            Expires = accessExpires,
            Path = "/" // full site
        };

        var refreshCookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = secure,
            SameSite = SameSiteMode.Strict,
            Expires = refreshExpires,
            Path = "/" // or "/" if you prefer
        };

        _httpContextAccessor.HttpContext?.Response.Cookies.Append("wla_access", accessToken, accessCookieOptions);
        _httpContextAccessor.HttpContext?.Response.Cookies.Append("wla_refresh", refreshToken, refreshCookieOptions);
    }

    private void ClearAuthCookies()
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete("wla_access");
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete("wla_refresh");
    }
}