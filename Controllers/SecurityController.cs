using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Repository;
using WowLogAnalyzer.Extensions;

namespace WowLogAnalyzer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityController : ControllerBase
{

    private readonly AppDbContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _config;

    public SecurityController(AppDbContext dbContext, IUserRepository userRepository, IConfiguration config)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var email = request.Email ?? "";
        var password = request.Password ?? "";
        var foundUser = await _userRepository.GetUserByEmailAsync(email);

        if (foundUser != null && BCrypt.Net.BCrypt.Verify(password, foundUser.Password))
        {
            var token = GenerateJwtToken(foundUser);
            return Ok(new
            {
                Token = token,
                ExpireMinutes = _config.GetSection("Jwt")["ExpireMinutes"] ?? "60",
                User = foundUser.ToResponse()
            });
        }


        return Unauthorized("Invalid credentials");
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? "NO KEY ENTERED"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"] ?? "60")),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}