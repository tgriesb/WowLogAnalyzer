using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moq;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Services;
using Xunit;

namespace WowLogAnalyzer.Tests.Services;

public class JwtSecurityServiceTests
{
    private static IConfiguration CreateMockConfiguration(
        string key = "RqUXMx7TUajhdHdtS1oC5TvWdYs1o4WwhCfmxJXaLUA", 
        string audience = "EndUsers",
        string issuer = "WowLogAnalyzer",
        int expiryMinutes = 60)
    {
        var config = new Mock<IConfiguration>();
        config.Setup(c => c["Jwt:Secret"]).Returns(key);
        config.Setup(c => c["Jwt:ExpireMinutes"]).Returns(expiryMinutes.ToString());
        config.Setup(c => c["Jwt:Key"]).Returns(key);
        config.Setup(c => c["Jwt:Audience"]).Returns(audience);
        config.Setup(c => c["Jwt:Issuer"]).Returns(issuer);
        return config.Object;
    }

    [Fact]
    public void GenerateJwtToken_ReturnsValidToken_ForUser()
    {
        var config = CreateMockConfiguration();
        var svc = new JwtSecurityService(config);

        var user = new User
        {
            Id = 123,
            Username = "testuser",
            Email = "test@example.com",
            Password = "hashed"
        };

        var token = svc.GenerateJwtToken(user);

        Assert.False(string.IsNullOrEmpty(token));

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.Equal("123", jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value);
        Assert.Equal("test@example.com", jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.UniqueName)?.Value);
    }

    [Fact]
    public void GenerateJwtToken_SetsCorrectExpiration()
    {
        var config = CreateMockConfiguration(expiryMinutes: 30);
        var svc = new JwtSecurityService(config);

        var user = new User { Id = 1, Username = "user", Email = "e@m.com", Password = "p" };

        var token = svc.GenerateJwtToken(user);

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var expiry = jwtToken.ValidTo;
        var now = DateTime.UtcNow;
        var expectedExpiry = now.AddMinutes(30);

        // Allow 1 minute tolerance for test execution time
        Assert.True(expiry >= expectedExpiry.AddMinutes(-1) && expiry <= expectedExpiry.AddMinutes(1));
    }

    [Fact]
    public void GetExpiry_ReturnsConfiguredValue()
    {
        var config = CreateMockConfiguration(expiryMinutes: 120);
        var svc = new JwtSecurityService(config);

        var expiry = svc.GetExpiry();

        Assert.Equal("120", expiry);
    }

    [Fact]
    public void GetExpiry_ReturnsDefault_WhenNotConfigured()
    {
        var config = new Mock<IConfiguration>();
        config.Setup(c => c["Jwt:Secret"]).Returns("test-secret-key-minimum-32-chars-long!");
        config.Setup(c => c["Jwt:ExpiryMinutes"]).Returns((string?)null);

        var svc = new JwtSecurityService(config.Object);

        var expiry = svc.GetExpiry();

        Assert.Equal("60", expiry); // default value
    }

    [Fact]
    public void GenerateJwtToken_TokenIsValidatable_WithCorrectSecret()
    {
        var secret = "my-super-secret-key-that-is-long-enough!";
        var config = CreateMockConfiguration(secret);
        var svc = new JwtSecurityService(config);

        var user = new User { Id = 99, Username = "alice", Email = "alice@test.com", Password = "pwd" };

        var token = svc.GenerateJwtToken(user);

        var handler = new JwtSecurityTokenHandler();
        var validationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        var principal = handler.ValidateToken(token, validationParams, out var validatedToken);

        Assert.NotNull(principal);
        Assert.Equal("99", principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        Assert.Equal("alice@test.com", principal.FindFirst(ClaimTypes.Name)?.Value);
    }

    [Fact]
    public void GenerateJwtToken_IncludesAllUserClaims()
    {
        var config = CreateMockConfiguration();
        var svc = new JwtSecurityService(config);

        var user = new User
        {
            Id = 42,
            Username = "bob",
            Email = "bob@mail.com",
            Password = "secure"
        };

            var token = svc.GenerateJwtToken(user);

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var claims = jwtToken.Claims.ToList();

        Assert.Contains(claims, c => c.Type == JwtRegisteredClaimNames.Sub && c.Value == "42");
        Assert.Contains(claims, c => c.Type == JwtRegisteredClaimNames.UniqueName && c.Value == "bob@mail.com");
    }
}