using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Repository;
using WowLogAnalyzer.Extensions;
using WowLogAnalyzer.Services;

namespace WowLogAnalyzer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityController(AppDbContext dbContext, IUserRepository userRepository, IJwtSecurityService jwtSecurityService) : ControllerBase
{

    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IJwtSecurityService _jwtSecurityService = jwtSecurityService ?? throw new ArgumentNullException(nameof(jwtSecurityService));

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var email = request.Email ?? "";
        var password = request.Password ?? "";
        var foundUser = await _userRepository.GetUserByEmailAsync(email);

        if (foundUser != null && BCrypt.Net.BCrypt.Verify(password, foundUser.Password))
        {
            var token = _jwtSecurityService.GenerateJwtToken(foundUser);
            return Ok(new
            {
                Token = token,
                ExpireMinutes = _jwtSecurityService.GetExpiry(),
                User = foundUser.ToResponse()
            });
        }

        return Unauthorized("Invalid credentials");
    }

}