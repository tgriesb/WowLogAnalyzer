using Microsoft.AspNetCore.Mvc;
using WowLogAnalyzer.Services;
using WowLogAnalyzer.Models;
using WowLogAnalyzer.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WowLogAnalyzer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityController(IAuthService auth, AppDbContext dbContext) : ControllerBase
{

    private readonly IAuthService _auth = auth ?? throw new ArgumentNullException(nameof(auth));
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

   [HttpPost("login")]
    public async Task<ActionResult<LoginDto>> Login([FromBody] LoginDto dto)
    {
        var result = await _auth.LoginAsync(
            dto.Email,
            dto.Password,
            dto.DeviceName ?? "Browser"
        );

        return Ok(result); // result is LoginDto
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<LoginDto>> Refresh()
    {
        var result = await _auth.RefreshAsync();
        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _auth.LogoutAsync();
        return Ok();
    }

    // -----------------------------
    // TODO: Logout ALL SESSIONS?
    // -----------------------------

    [Authorize]
    [HttpGet("me")]
    public async Task<ActionResult<LoginDto?>> Me()
    {
        // At this point JwtBearer should already have populated HttpContext.User
        if (User?.Identity == null || !User.Identity.IsAuthenticated)
        {
            // If we get here, auth really failed
            return Unauthorized();
        }

        // Try to get user id from "sub" (what you're putting in the token)
        var userIdClaim =
            User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ??
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
        {
            // Authenticated but no usable id in claims
            return Unauthorized();
        }

        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            return Unauthorized();
        }

        return Ok(new LoginDto
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username,
        });
    }
}