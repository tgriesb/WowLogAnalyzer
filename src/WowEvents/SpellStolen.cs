using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellStolen : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_STOLEN;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Player-4385-05E54EFC
    [LogField(2)] public string SourceName { get; set; } = "";       // "Hsojie-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }         // 0x514
    [LogField(4)] public int SourceRaidFlags { get; set; }         // 0x80000040
    [LogField(5)] public string DestGUID { get; set; } = "";         // Creature-0-4391-1008-23606-60402-000016B4F2
    [LogField(6)] public string DestName { get; set; } = "";         // "Zandalari Fire-Dancer"
    [LogField(7)] public int DestFlags { get; set; }         // 0xa48
    [LogField(8)] public int DestRaidFlags { get; set; }        // 0x80000000
    [LogField(9)] public int SpellId { get; set; }       // 30449
    [LogField(10)] public string SpellName { get; set; } = "";       // "Spellsteal"
    [LogField(11)] public int SpellSchool { get; set; }          // 0x40
    [LogField(12)] public int StolenSpellId { get; set; }       // 116592
    [LogField(13)] public string StolenSpellName { get; set; } = "";       // "Blazing Speed"
    [LogField(14)] public int StolenSpellSchool { get; set; }          // 4
    [LogField(15)] public string StolenType { get; set; } = "";     // BUFF    
}