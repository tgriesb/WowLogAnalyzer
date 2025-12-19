namespace WowLogAnalyzer.Services;
public interface ICombatAnalyticsService
{
    public Task<List<EncounterListDto>> GetEncountersAsync(int logId);

    public Task<List<EncounterStatsPerIntervalDto>> GetEncounterStatsPerInterval(int encounterId, int intervalSeconds = 5);

    public Task<List<EncounterStatsPerIntervalDto>> GetEncounterStatsPerIntervalByLogId(int logId, int intervalSeconds = 5, bool includeTrash = false);
    public Task<List<EncounterCharacterStatsDto>> GetLogDetails(int logId, bool includeTrash = false);
    public Task<List<EncounterCharacterStatsDto>> GetEncounterDetails(int encounterId);

}