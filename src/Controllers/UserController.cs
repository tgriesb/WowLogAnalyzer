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

/// <summary>
/// Manages user accounts and profiles.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserController(AppDbContext dbContext, IUserRepository userRepository, IJwtSecurityService jwtSecurityService) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IJwtSecurityService _jwtSecurityService = jwtSecurityService ?? throw new ArgumentNullException(nameof(jwtSecurityService));


    /// <summary>
    /// Retrieves a list of all user accounts.
    /// </summary>
    /// <remarks>
    /// <strong>Note:</strong> This endpoint does not require authentication and returns basic user information.
    /// Consider adding authorization if this is sensitive data.
    /// </remarks>
    /// <returns>A collection of all users.</returns>
    /// <response code="200">Returns the list of all users.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<User>>> Index()
    {
        var users = await _userRepository.GetUsersAsync();
    
        // Return an OkObjectResult with the list of users.
        return Ok(users.ToResponseList());
    }

    /// <summary>
    /// Retrieves a specific user account by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The user profile information.</returns>
    /// <response code="200">Returns the requested user.</response>
    /// <response code="404">If the user is not found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.ToResponse());
    }

    /// <summary>
    /// Creates a new user account.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Validates the username and email are unique before creating the account.
    /// Password is hashed using bcrypt before being stored.
    /// </para>
    /// <para>
    /// If the request is made by an authenticated user, a JWT token is returned immediately.
    /// Otherwise, a 201 Created response is returned with the user location.
    /// </para>
    /// </remarks>
    /// <param name="request">The user creation details (username, email, password).</param>
    /// <returns>The created user profile and optionally a JWT token.</returns>
    /// <response code="200">User created and authenticated. Returns JWT token.</response>
    /// <response code="201">User created but not authenticated. Returns location header.</response>
    /// <response code="400">If the request model is invalid.</response>
    /// <response code="409">If the username or email is already registered.</response>
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
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