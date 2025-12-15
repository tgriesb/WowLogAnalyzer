using Microsoft.AspNetCore.Mvc;
using WowLogAnalyzer.Services;
using WowLogAnalyzer.Models;
using WowLogAnalyzer.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WowLogAnalyzer.Controllers;

/// <summary>
/// Handles user authentication and token management.
/// Implements a secure flow using short-lived JWT access tokens and long-lived HttpOnly refresh cookies.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SecurityController(IAuthService auth, AppDbContext dbContext) : ControllerBase
{

    private readonly IAuthService _auth = auth ?? throw new ArgumentNullException(nameof(auth));
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    /// <summary>
    /// Authenticates a user and establishes a new session.
    /// </summary>
    /// <remarks>
    /// <para>
    /// On success, this endpoint returns a short-lived <strong>Access Token</strong> in the response body
    /// for use in Authorization headers.
    /// </para>
    /// <para>
    /// It also sets a secure, HttpOnly <strong>Refresh Token</strong> cookie. This cookie is used automatically
    /// by the <c>/refresh</c> endpoint to get new access tokens when the current one expires.
    /// </para>
    /// </remarks>
    /// <param name="loginDto">The user's email and password.</param>
    /// <returns>The access token and user profile information.</returns>
    /// <response code="200">Login successful.</response>
    /// <response code="401">Invalid email or password.</response>
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

    /// <summary>
    /// Refreshes an expired Access Token using the secure Refresh Token cookie.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This endpoint is typically called by the frontend's API interceptor when a 401 Unauthorized response is received.
    /// </para>
    /// <para>
    /// It performs <strong>Token Rotation</strong>: The old refresh token is invalidated, and a new one is issued
    /// in the Set-Cookie header.
    /// </para>
    /// </remarks>
    /// <returns>A new Access Token.</returns>
    /// <response code="200">Token refreshed successfully.</response>
    /// <response code="401">If the refresh token cookie is missing, expired, or invalid.</response>
    [HttpPost("refresh")]
    public async Task<ActionResult<LoginDto>> Refresh()
    {
        var result = await _auth.RefreshAsync();
        return Ok(result);
    }


    /// <summary>
    /// Logs the user out by invalidating the session.
    /// </summary>
    /// <remarks>
    /// This instructs the browser to delete the Refresh Token cookie.
    /// The frontend should also clear the Access Token from memory.
    /// </remarks>
    /// <returns>Success message.</returns>
    /// <response code="200">Logged out successfully.</response>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _auth.LogoutAsync();
        return Ok();
    }

    // -----------------------------
    // TODO: Logout ALL SESSIONS?
    // -----------------------------


    /// <summary>
    /// Helper method to set the Refresh Token in an HttpOnly cookie.
    /// </summary>
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