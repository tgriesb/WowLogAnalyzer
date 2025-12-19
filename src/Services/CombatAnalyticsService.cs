using Microsoft.EntityFrameworkCore;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Enums;


namespace WowLogAnalyzer.Services;

/// <summary>
/// Service responsible for analyzing combat data and generating statistics.
/// Handles encounter retrieval, character performance metrics, and interval-based analysis.
/// </summary>
public class CombatAnalyticsService(AppDbContext dbContext) : ICombatAnalyticsService
{
    private readonly AppDbContext _dbContext = dbContext;

    /// <summary>
    /// Retrieves all encounters associated with a specific log.
    /// </summary>
    /// <param name="logId">The ID of the log.</param>
    /// <returns>A collection of encounter summaries.</returns>
    public async Task<List<EncounterListDto>> GetEncountersAsync(int logId)
    {
        var query = _dbContext.Encounters
            .Where(e => e.LogId == logId);

        var encounters = await query
            .Select(e => new EncounterListDto
            {
                Id = e.Id,
                Name = $"{e.EncounterName}",
                Duration = string.Format(
                    "{0:D2}:{1:D2}",
                    (int)(e.EndCombatEvent.Timestamp - e.StartCombatEvent.Timestamp).TotalMinutes,
                    (e.EndCombatEvent.Timestamp - e.StartCombatEvent.Timestamp).Seconds
                ),
                StartedAt = e.StartCombatEvent.Timestamp,
                EndedAt = e.StartCombatEvent.Timestamp,
                Success = e.Success,
                Instance = ""
            })
            .ToListAsync();

        return encounters;
    }


    /// <summary>
    /// Calculates encounter statistics aggregated over fixed time intervals.
    /// Useful for generating graphs of DPS/HPS over time.
    /// </summary>
    /// <param name="encounterId">The ID of the encounter.</param>
    /// <param name="intervalSeconds">The duration of each interval in seconds.</param>
    /// <returns>A list of aggregated stats per interval.</returns>
    public async Task<List<EncounterStatsPerIntervalDto>> GetEncounterStatsPerInterval(int encounterId, int intervalSeconds = 5)
    {
        var results = await _dbContext.Database.SqlQuery<EncounterStatsPerIntervalDto>($@"
            WITH encounter_start AS (
                SELECT MIN(timestamp) AS start_time
                FROM combat_events
                WHERE encounter_id = {encounterId}
            )

            SELECT
                CAST(
                    FLOOR(
                        EXTRACT(
                            EPOCH FROM (combat_events.timestamp - encounter_start.start_time)
                        ) / {intervalSeconds}
                    ) * {intervalSeconds} AS int
                ) AS seconds_interval,
                SUM(CASE WHEN combat_events.amount_type = {AmountType.DAMAGE} THEN combat_events.amount ELSE 0 END) as total_damage,
                SUM(CASE WHEN combat_events.amount_type = {AmountType.HEAL} THEN combat_events.amount ELSE 0 END) as total_healing,
                SUM(CASE WHEN combat_events.amount_type = {AmountType.ABSORB} THEN combat_events.amount ELSE 0 END) as total_absorb
            FROM encounters
            INNER JOIN character_encounters ON character_encounters.encounter_id = encounters.id
            INNER JOIN characters ON characters.id = character_encounters.character_id
            INNER JOIN combat_events 
                ON combat_events.encounter_id = encounters.id AND
                combat_events.from_character_id = characters.id
            LEFT JOIN specs ON specs.id = character_encounters.spec_id
            CROSS JOIN encounter_start
            WHERE encounters.id = {encounterId}
            AND combat_events.amount_type IS NOT NULL
            GROUP BY
                seconds_interval
            ORDER BY
                seconds_interval
        ").ToListAsync();

        return results;
    }

    /// <summary>
    /// Calculates encounter statistics aggregated over fixed time intervals.
    /// Useful for generating graphs of DPS/HPS over time.
    /// </summary>
    /// <param name="logId">The ID of the log.</param>
    /// <param name="intervalSeconds">The duration of each interval in seconds.</param>
    /// <param name="includeTrash">Whether to include trash encounters.</param>
    /// <returns>A list of aggregated stats per interval.</returns>
    public async Task<List<EncounterStatsPerIntervalDto>> GetEncounterStatsPerIntervalByLogId(int logId, int intervalSeconds = 5, bool includeTrash = false)
    {
        var results = await _dbContext.Database.SqlQuery<EncounterStatsPerIntervalDto>($@"
            WITH encounter_bounds AS (
                SELECT
                    encounter_id,
                    MIN(timestamp) AS start_time,
                    MAX(timestamp) AS end_time
                FROM combat_events
                WHERE log_id = {logId}
                GROUP BY encounter_id
            ),
            encounter_offsets AS (
                SELECT
                    encounter_id,
                    start_time,
                    end_time,

                    COALESCE(
                        SUM(
                            EXTRACT(EPOCH FROM (end_time - start_time))
                        ) OVER (
                            ORDER BY start_time
                            ROWS BETWEEN UNBOUNDED PRECEDING AND 1 PRECEDING
                        ),
                        0
                    ) AS compressed_offset_seconds
                FROM encounter_bounds
            ),
            events_with_raw_seconds AS (
                SELECT
                    ce.encounter_id,
                    ce.amount_type,
                    ce.amount,

                    (
                        EXTRACT(EPOCH FROM (ce.timestamp - eo.start_time))
                        + eo.compressed_offset_seconds
                    ) AS raw_seconds

                FROM combat_events ce
                INNER JOIN encounter_offsets eo
                    ON eo.encounter_id = ce.encounter_id

                WHERE ce.log_id = {logId}
                AND ce.amount_type IS NOT NULL
            ),
            events_with_seconds AS (
                SELECT
                    *,
                    CAST(
                        FLOOR(
                            (raw_seconds - MIN(raw_seconds) OVER ())
                            / {intervalSeconds}
                        ) * {intervalSeconds}
                        AS int
                    ) AS seconds_interval
                FROM events_with_raw_seconds
            )
            SELECT
                encounter_id,
                seconds_interval,

                SUM(CASE WHEN amount_type = {AmountType.DAMAGE} THEN amount ELSE 0 END) AS total_damage,
                SUM(CASE WHEN amount_type = {AmountType.HEAL}   THEN amount ELSE 0 END) AS total_healing,
                SUM(CASE WHEN amount_type = {AmountType.ABSORB} THEN amount ELSE 0 END) AS total_absorb

            FROM events_with_seconds
            GROUP BY
                encounter_id,
                seconds_interval
            ORDER BY
                seconds_interval;

        ").ToListAsync();

        return results;
    }


    /// <summary>
    /// Retrieves detailed character performance statistics for a specific encounter.
    /// Calculates damage, healing, and absorb metrics for each participant.
    /// </summary>
    /// <param name="encounterId">The ID of the encounter.</param>
    /// <returns>A collection of character statistics for the encounter.</returns>
    public async Task<List<EncounterCharacterStatsDto>> GetEncounterDetails(int encounterId)
    {
        var results = await _dbContext.Database.SqlQuery<EncounterCharacterStatsDto>($@"
            SELECT
                characters.id as character_id,
                characters.name as character,
                specs.name as spec,
                specs.class as ""class"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.DAMAGE} THEN combat_events.amount ELSE 0 END) as total_damage,
                SUM(CASE WHEN combat_events.amount_type = {AmountType.HEAL} THEN combat_events.amount ELSE 0 END) as total_healing,
                SUM(CASE WHEN combat_events.amount_type = {AmountType.ABSORB} THEN combat_events.amount ELSE 0 END) as total_absorb,
                COALESCE(d.deaths, 0) AS deaths,
                COALESCE(taken.damage_taken, 0) AS total_damage_taken
            FROM encounters
            INNER JOIN character_encounters ON character_encounters.encounter_id = encounters.id
            INNER JOIN characters ON characters.id = character_encounters.character_id
            LEFT JOIN combat_events 
                ON combat_events.encounter_id = encounters.id AND
                combat_events.from_character_id = characters.id
            LEFT JOIN (
                SELECT 
                    to_character_id,
                    COUNT(*) AS deaths
                FROM combat_events
                WHERE encounter_id = {encounterId}
                AND event_type = 600
                GROUP BY to_character_id
            ) d ON d.to_character_id = characters.id
			 LEFT JOIN (
			    SELECT 
			        to_character_id,
					SUM(CASE WHEN combat_events.amount_incoming_type = {AmountType.DAMAGE} THEN combat_events.amount_incoming ELSE 0 END)  AS damage_taken
			    FROM combat_events
			    WHERE encounter_id = {encounterId}
			    GROUP BY to_character_id
			) taken ON taken.to_character_id = characters.id
            LEFT JOIN specs ON specs.id = character_encounters.spec_id
            WHERE encounters.id = {encounterId}
            AND combat_events.amount_type IS NOT NULL
            GROUP BY
                characters.id,
                characters.name,
                specs.name,
                specs.class,
                d.deaths,
                taken.damage_taken
            ORDER BY
                characters.id
        ").ToListAsync();

        return results;
    }

    /// <summary>
    /// Retrieves detailed character performance statistics for a specific log.
    /// Calculates damage, healing, and absorb metrics for each participant.
    /// </summary>
    /// <param name="logId">The ID of the log.</param>
    /// <param name="includeTrash">Whether to include trash encounters.</param>
    /// <returns>A collection of character statistics for the log.</returns>
    public async Task<List<EncounterCharacterStatsDto>> GetLogDetails(int logId, bool includeTrash = false)
    {
        var results = await _dbContext.Database.SqlQuery<EncounterCharacterStatsDto>($@"
            SELECT
                characters.id as character_id,
                characters.name as character,
                specs.name as spec,
                specs.class as ""class"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.DAMAGE} THEN combat_events.amount ELSE 0 END) as total_damage,
                SUM(CASE WHEN combat_events.amount_type = {AmountType.HEAL} THEN combat_events.amount ELSE 0 END) as total_healing,
                SUM(CASE WHEN combat_events.amount_type = {AmountType.ABSORB} THEN combat_events.amount ELSE 0 END) as total_absorb,
                COALESCE(d.deaths, 0) AS deaths,
                COALESCE(taken.damage_taken, 0) AS total_damage_taken
            FROM encounters
            INNER JOIN character_encounters ON character_encounters.encounter_id = encounters.id
            INNER JOIN characters ON characters.id = character_encounters.character_id
            LEFT JOIN combat_events 
                ON combat_events.encounter_id = encounters.id AND
                combat_events.from_character_id = characters.id
            LEFT JOIN (
                SELECT 
                    to_character_id,
                    COUNT(*) AS deaths
                FROM combat_events
                WHERE encounter_id IN (SELECT id FROM encounters WHERE log_id = {logId})
                AND event_type = 600
                GROUP BY to_character_id
            ) d ON d.to_character_id = characters.id
			 LEFT JOIN (
			    SELECT 
			        to_character_id,
					SUM(CASE WHEN combat_events.amount_incoming_type = {AmountType.DAMAGE} THEN combat_events.amount_incoming ELSE 0 END)  AS damage_taken
			    FROM combat_events
			    WHERE encounter_id IN (SELECT id FROM encounters WHERE log_id = {logId})
			    GROUP BY to_character_id
			) taken ON taken.to_character_id = characters.id
            LEFT JOIN specs ON specs.id = character_encounters.spec_id
            WHERE encounters.id IN (SELECT id FROM encounters WHERE log_id = {logId})
            AND combat_events.amount_type IS NOT NULL
            GROUP BY
                characters.id,
                characters.name,
                specs.name,
                specs.class,
                d.deaths,
                taken.damage_taken
            ORDER BY
                characters.id
        ").ToListAsync();

        return results;
    }

    public static IEnumerable<int> DamageEvents()
    {
        return [
            (int) CombatSubEventType.SWING_DAMAGE,
            (int) CombatSubEventType.RANGE_DAMAGE,
            (int) CombatSubEventType.SPELL_DAMAGE,
            (int) CombatSubEventType.SPELL_PERIODIC_DAMAGE
        ];
    }
}

