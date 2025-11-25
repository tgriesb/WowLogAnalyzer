using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Repository;
using WowLogAnalyzer.Extensions;
using WowLogAnalyzer.Response;
using WowLogAnalyzer.Models;
using System.Security.Claims;
using WowLogAnalyzer.Services; // added for CreateUserRequest

namespace WowLogAnalyzer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(AppDbContext dbContext, IUserRepository userRepository, IJwtSecurityService jwtSecurityService) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IJwtSecurityService _jwtSecurityService = jwtSecurityService ?? throw new ArgumentNullException(nameof(jwtSecurityService));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Index()
    {
        var users = await _userRepository.GetUsersAsync();
    
        // Return an OkObjectResult with the list of users.
        return Ok(users.ToResponseList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.ToResponse());
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Check uniqueness using the DbContext (repository may provide methods; adapt if available)
        if (await _dbContext.Users.AnyAsync(u => u.Username == request.Username))
            return Conflict(new { error = "Username already taken" });

        if (await _dbContext.Users.AnyAsync(u => u.Email == request.Email))
            return Conflict(new { error = "Email already registered" });

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            Password = WowLogAnalyzer.Entities.User.HashPassword(request.Password)
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (loggedInUserId != null)
        {
            // Log user in
            var token = _jwtSecurityService.GenerateJwtToken(user);
            return Ok(new
            {
                Token = token,
                ExpireMinutes = _jwtSecurityService.GetExpiry(),
                User = user.ToResponse()
            });
        }

        // Return 201 with location header to GET the created user
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user.ToResponse());
    }
}