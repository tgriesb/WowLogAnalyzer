namespace WowLogAnalyzer.Services;
public interface ICombatAnalyticsService
{
    public Task<List<EncounterListDto>> GetEncountersAsync(int logId);

    public Task<List<GetEncounterStatsPerIntervalDto>> GetEncounterStatsPerInterval(int encounterId, int intervalSeconds = 5);

    public Task<List<EncounterCharacterStatsDto>> GetEncounterDetails(int encounterId);

}