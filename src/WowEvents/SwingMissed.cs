using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SwingMissed : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SWING_MISSED;

    [LogField(1)] public string SourceGUID { get; set; } = "";          // Player-4385-05E6580C
    [LogField(2)] public string SourceName { get; set; } = "";          // "Heathedger-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }            // 0x512
    [LogField(4)] public int SourceRaidFlags { get; set; }            // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";            // Vehicle-0-4389-996-4799-60585-00001687E9
    [LogField(6)] public string DestName { get; set; } = "";            // "Elder Regail"
    [LogField(7)] public int DestFlags { get; set; }            // 0x10a48
    [LogField(8)] public int DestRaidFlags { get; set; }               // 0x80000080
    [LogField(9)] public string MissType { get; set; } = "";          // MISS
    [LogField(10)] public bool IsOffHand { get; set; }             // 1
}