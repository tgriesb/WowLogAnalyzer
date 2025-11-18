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

namespace WowLogAnalyzer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IUserRepository _userRepository;

    public UserController(AppDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

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
    public async Task<ActionResult<UserResponse>> Create([FromBody] User user)
    {
        if (ModelState.IsValid)
        {
            user.Password = WowLogAnalyzer.Entities.User.HashPassword(user.Password);
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirect to a list view
        }
        return user.ToResponse();
    }
    
    
}