using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class UnitDissipates : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.UNIT_DISSIPATES;

    [LogField(1)] public string SourceGUID { get; set; } = "";         // 0000000000000000
    [LogField(2)] public string SourceName { get; set; } = "";         // nil
    [LogField(3)] public long SourceFlags { get; set; }           // 0x80000000
    [LogField(4)] public long SourceRaidFlags { get; set; }           // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";           // Creature-0-4389-996-4799-60885-0000168C66
    [LogField(6)] public string DestName { get; set; } = "";           // "Minion of Fear"
    [LogField(7)] public long DestFlags { get; set; }           // 0xa48
    [LogField(8)] public long DestRaidFlags { get; set; }              // 0x80000000
    [LogField(9)] public string RecapId { get; set; } = "";         // 0
}