using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class PartyKill : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.PARTY_KILL;

    [LogField(1)] public string SourceGUID { get; set; } = "";    // Player-4385-05E6580C
    [LogField(2)] public string SourceName { get; set; } = "";    // "Heathedger-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }    // 0x512
    [LogField(4)] public int SourceRaidFlags { get; set; }    // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";    // Creature-0-4389-996-4799-60885-0000168C76
    [LogField(6)] public string DestName { get; set; } = "";    // "Minion of Fear"
    [LogField(7)] public int DestFlags { get; set; }    // 0xa48
    [LogField(8)] public int DestRaidFlags { get; set; }    // 0x80000000
}