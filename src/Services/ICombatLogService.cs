using WowLogAnalyzer.Entities;

namespace WowLogAnalyzer.Services;

public interface ICombatLogService
{
    public Task ParseLogFileAsync(IFormFile file, Log log);

}