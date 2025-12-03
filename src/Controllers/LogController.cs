using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Repository;
using WowLogAnalyzer.Services;

namespace WowLogAnalyzer.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LogController(
    AppDbContext dbContext,
    IUserRepository userRepository,
    IConfiguration config,
    ICombatLogService combatLogService,
    ICombatAnalyticsService combatAnalyticsService
    ) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IConfiguration _config = config ?? throw new ArgumentNullException(nameof(config));

    private readonly ICombatLogService _combatLogService = combatLogService ?? throw new ArgumentNullException(nameof(combatLogService));
    private readonly ICombatAnalyticsService _combatAnalyticsService = combatAnalyticsService ?? throw new ArgumentNullException(nameof(combatAnalyticsService));

    [HttpGet()]
    public async Task<IActionResult> Logs([FromQuery] int page = 0, [FromQuery] int pageSize = 0)
    {
        var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (loggedInUserId == null)
        {
            return Unauthorized(new { message = "Not authorized" });
        }

        IQueryable<Log> logsQuery = _dbContext.Logs
            .Where(log => log.UserId == int.Parse(loggedInUserId))
            .OrderBy(log => log.Id);

        if (page > 0 && pageSize > 0)
        {
            int recordsToSkip = (page - 1) * pageSize;
            logsQuery = logsQuery.Skip(recordsToSkip).Take(pageSize);
        }

        var logs = await logsQuery.ToListAsync();

        return Ok(logs);
    }


    [HttpPost("upload")]
    [RequestSizeLimit(1_000_000_000)]
    [RequestFormLimits(ValueLengthLimit = 1_000_000_000, MultipartBodyLengthLimit = 1_000_000_000)]
    public async Task<IActionResult> Upload(IFormFile file, [FromForm] string? logName)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest(new { message = "No file uploaded" });
        }

        var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (loggedInUserId == null)
        {
            return Unauthorized(new { message = "Not authorized" });
        }

        Log log = new()
        {
            Name = logName ?? "",
            FileName = file.FileName,
            UploadedAt = DateTime.Now.ToUniversalTime(),
            UserId = int.Parse(loggedInUserId)
        };

        _dbContext.Logs.Add(log);

        await _dbContext.SaveChangesAsync();

        await _combatLogService.ParseLogFileAsync(file, log);

        return Ok(new
        {
            LogId = log.Id
        });
    }
    
    
    [HttpGet("encounters/{logId}")]
    public async Task<IActionResult> GetEncounters(int logId)
    {
        var log = await _dbContext.Logs.FindAsync(logId);
        if (log == null)
        {
            return NotFound();
        }
        var encounters = await _combatAnalyticsService.GetEncountersAsync(logId);
        
        return Ok(new
        {
            Encounters = encounters,
            Log = log
        });
    }

    [HttpGet("encounter/{encounterId}")]
    public async Task<IActionResult> GetEncounter(int encounterId)
    {
        var encounter = await _dbContext.Encounters.FindAsync(encounterId);
        if (encounter == null)
        {
            return NotFound();
        }

        var characters = await _combatAnalyticsService.GetEncounterDetails(encounterId);
    
        return Ok(new
        {
            Characters = characters,
            Encounter = encounter,
        });
    }


    [HttpGet("encounter-statistics-by-interval/{encounterId}")]
    public async Task<IActionResult> GetEncounterStatisticsByInterval(int encounterId)
    {
        var encounter = await _dbContext.Encounters.FindAsync(encounterId);
        if (encounter == null)
        {
            return NotFound();
        }

        var statistics = await _combatAnalyticsService.GetEncounterStatsPerInterval(encounterId, 5);
        return Ok(statistics);
    }   
}