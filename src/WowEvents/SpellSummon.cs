using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellSummon : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_SUMMON;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Player-4385-05E54EFC
    [LogField(2)] public string SourceName { get; set; } = "";       // "Hsojie-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }         // 0x514
    [LogField(4)] public int SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";         // Creature-0-4389-996-4799-60199-0000168C4D
    [LogField(6)] public string DestName { get; set; } = "";         // "Rune of Power"
    [LogField(7)] public int DestFlags { get; set; }         // 0xa28
    [LogField(8)] public int DestRaidFlags { get; set; }        // 0x80000000
    [LogField(9)] public int SpellId { get; set; }       // 116011
    [LogField(10)] public string SpellName { get; set; } = "";       // "Rune of Power"
    [LogField(11)] public int SpellSchool { get; set; }          // 0x40
}