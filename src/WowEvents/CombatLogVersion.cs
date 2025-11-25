using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class CombatLogVersion : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.COMBAT_LOG_VERSION;

    [LogField(1)] public string Version { get; set; } = ""; // 9
    [LogField(3)] public bool AdvancedLogEnabled { get; set; }  // 1
    [LogField(5)] public string BuildVersion { get; set; } = ""; //5.5.2
    [LogField(7)] public int ProjectId { get; set; } // 19
}
