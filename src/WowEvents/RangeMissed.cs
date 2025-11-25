using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class RangeMissed : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.RANGE_MISSED;

    [LogField(1)] public string SourceGUID { get; set; } = "";   // Player-4385-05E55270
    [LogField(2)] public string SourceName { get; set; } = "";   // "Snippss-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }     // 0x512
    [LogField(4)] public int SourceRaidFlags { get; set; }     // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";     // Creature-0-4389-996-4799-62983-0000168F94
    [LogField(6)] public string DestName { get; set; } = "";     // "Lei Shi"
    [LogField(7)] public int DestFlags { get; set; }     // 0x10a48
    [LogField(8)] public int DestRaidFlags { get; set; }    // 0x80000000
    [LogField(9)] public int SpellId { get; set; }   // 75
    [LogField(10)] public string SpellName { get; set; } = "";   // "Auto Shot"
    [LogField(11)] public int SpellSchool { get; set; }      // 0x1
    [LogField(12)] public string MissType { get; set; } = "";   // IMMUNE
    [LogField(13)] public string IsOffHand { get; set; } = "";    // nil

}