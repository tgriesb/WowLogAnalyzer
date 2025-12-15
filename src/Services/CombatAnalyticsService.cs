using Microsoft.EntityFrameworkCore;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Enums;
using WowLogAnalyzer.WowEvents;

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
        return await _dbContext.Encounters
            .Where(e => e.LogId == logId)
            .OrderBy(e => e.StartCombatEvent.Timestamp)
            .Select(e => new EncounterListDto
            {
                Id = e.Id,
                Name = e.EncounterName,
                Duration = string.Format(
                    "{0:D2}:{1:D2}",
                    (int)(e.EndCombatEvent.Timestamp - e.StartCombatEvent.Timestamp).TotalMinutes,
                    (e.EndCombatEvent.Timestamp - e.StartCombatEvent.Timestamp).Seconds
                ),
                StartedAt = e.StartCombatEvent.Timestamp,
                EndedAt = e.EndCombatEvent.Timestamp,
                Success = e.Success,
                Instance = "" // Placeholder as per original code
            })
            .ToListAsync();
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
                characters.id as ""CharacterId"",
                characters.name as ""Character"",
                specs.name as ""Spec"",
                specs.class as ""Class"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.DAMAGE} THEN combat_events.amount ELSE 0 END) as ""TotalDamage"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.HEAL} THEN combat_events.amount ELSE 0 END) as ""TotalHealing"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.ABSORB} THEN combat_events.amount ELSE 0 END) as ""TotalAbsorb"",
                COALESCE(d.deaths, 0) AS ""Deaths"",
                COALESCE(taken.damage_taken, 0) AS ""TotalDamageTaken""
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
    /// Calculates encounter statistics aggregated over fixed time intervals.
    /// Useful for generating graphs of DPS/HPS over time.
    /// </summary>
    /// <param name="encounterId">The ID of the encounter.</param>
    /// <param name="intervalSeconds">The duration of each interval in seconds.</param>
    /// <returns>A list of aggregated stats per interval.</returns>
    public async Task<List<GetEncounterStatsPerIntervalDto>> GetEncounterStatsPerInterval(int encounterId, int intervalSeconds = 5)
    {
        var results = await _dbContext.Database.SqlQuery<GetEncounterStatsPerIntervalDto>($@"
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
                    ) * {intervalSeconds} AS double precision
                ) AS ""SecondsInterval"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.DAMAGE} THEN combat_events.amount ELSE 0 END) as ""TotalDamage"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.HEAL} THEN combat_events.amount ELSE 0 END) as ""TotalHealing"",
                SUM(CASE WHEN combat_events.amount_type = {AmountType.ABSORB} THEN combat_events.amount ELSE 0 END) as ""TotalAbsorb""
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
                ""SecondsInterval""
            ORDER BY
                ""SecondsInterval""
        ").ToListAsync();

        return results;
    }
}

public class EncounterListDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public bool Success { get; set; }
    public string Duration { get; set; } = String.Empty;
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }
    public string Instance { get; set; } = String.Empty;
}

public class EncounterCharacterStatsDto
{
    public int CharacterId { get; set; }
    public string Character { get; set; } = "";
    public string Spec { get; set; } = "";
    public string Class { get; set; } = "";
    public double TotalDamage { get; set; }
    public double TotalAbsorb { get; set; }
    public double TotalHealing { get; set; }
    public int Deaths { get; set; }
    public double TotalDamageTaken { get; set; }

}

public class GetEncounterStatsPerIntervalDto
{
    public double SecondsInterval { get; set; }
    public double TotalDamage { get; set; }
    public double TotalAbsorb { get; set; }
    public double TotalHealing { get; set; }
}
