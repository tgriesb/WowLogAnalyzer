using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Repository;
using WowLogAnalyzer.Services;

namespace WowLogAnalyzer.Controllers;

/// <summary>
/// Manages the upload and retrieval of World of Warcraft combat logs.
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
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


    /// <summary>
    /// Retrieves all combat logs uploaded by the authenticated user with optional pagination.
    /// </summary>
    /// <remarks>
    /// Results are sorted by log ID in ascending order.
    /// </remarks>
    /// <param name="page">The page number (1-based). Set to 0 to retrieve all logs without pagination.</param>
    /// <param name="pageSize">The number of results per page. Ignored if page is 0.</param>
    /// <returns>A collection of log summaries.</returns>
    /// <response code="200">Returns the list of logs for the current user.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<Log>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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


    /// <summary>
    /// Uploads and parses a World of Warcraft combat log file.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Accepts a <c>.txt</c> file via multipart/form-data. The file is processed line-by-line to:
    /// <list type="bullet">
    /// <item><description>Detect and extract boss encounters (ENCOUNTER_START/END events)</description></item>
    /// <item><description>Parse combat events (damage, healing, auras, casts)</description></item>
    /// <item><description>Identify and create character profiles from player GUIDs</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// <strong>File Requirements:</strong>
    /// <list type="bullet">
    /// <item><description>Must be a <c>.txt</c> file (WoW's default combat log format)</description></item>
    /// <item><description>Cannot be empty</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// <strong>Size Limit:</strong> Maximum 1 GB per file.
    /// </para>
    /// <para>
    /// <strong>Performance Note:</strong> Large log files may take 10-30 seconds to process.
    /// </para>
    /// </remarks>
    /// <param name="file">The combat log text file to upload.</param>
    /// <param name="logName">Optional custom name for the log. If not provided, defaults to empty string.</param>
    /// <returns>The ID of the created log.</returns>
    /// <response code="200">Log successfully uploaded and parsed.</response>
    /// <response code="400">If the file is missing or empty.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [HttpPost("upload")]
    [RequestSizeLimit(1_000_000_000)]
    [RequestFormLimits(ValueLengthLimit = 1_000_000_000, MultipartBodyLengthLimit = 1_000_000_000)]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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


    /// <summary>
    /// Retrieves all encounters from a specific combat log.
    /// </summary>
    /// <remarks>
    /// Returns a summary of all boss encounters detected in the log along with the log metadata.
    /// </remarks>
    /// <param name="logId">The unique identifier of the log.</param>
    /// <returns>A collection of encounters and the log details.</returns>
    /// <response code="200">Returns the list of encounters.</response>
    /// <response code="404">If the log is not found.</response>
    [HttpGet("encounters/{logId}")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Retrieves detailed statistics for a specific encounter.
    /// </summary>
    /// <remarks>
    /// Returns character-level performance data (damage, healing, deaths, etc.) for all participants in the encounter.
    /// </remarks>
    /// <param name="encounterId">The unique identifier of the encounter.</param>
    /// <returns>Character performance details and encounter metadata.</returns>
    /// <response code="200">Returns the encounter details with character statistics.</response>
    /// <response code="404">If the encounter is not found.</response>
    [HttpGet("encounter/{encounterId}")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Retrieves encounter statistics aggregated at fixed time intervals.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This endpoint breaks down the encounter into 5-second intervals and calculates aggregate statistics
    /// (DPS, HPS, deaths, etc.) for each interval. Useful for visualizing performance trends over time.
    /// </para>
    /// </remarks>
    /// <param name="encounterId">The unique identifier of the encounter.</param>
    /// <returns>Time-series statistics for the encounter, grouped by 5-second intervals.</returns>
    /// <response code="200">Returns interval-based statistics.</response>
    /// <response code="404">If the encounter is not found.</response>
    [HttpGet("encounter-statistics-by-interval/{encounterId}")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Deletes a log by its ID.
    /// </summary>
    /// <param name="id">The ID of the log to delete.</param>
    /// <returns>No content if successful, or not found if the log does not exist.</returns>
    /// <response code="204">Log deleted successfully.</response>
    /// <response code="404">Log not found.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var log = await _dbContext.Logs.FindAsync(id);

        if (log == null)
            return NotFound();

        _dbContext.Logs.Remove(log);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}