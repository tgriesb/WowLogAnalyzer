using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellAuraBrokenSpell : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_AURA_BROKEN_SPELL;

    [LogField(1)] public string SourceGUID { get; set; } = "";    // Player-4385-05E55270
    [LogField(2)] public string SourceName { get; set; } = "";    // "Snippss-Immerseus-US"
    [LogField(3)] public long SourceFlags { get; set; }      // 0x512
    [LogField(4)] public long SourceRaidFlags { get; set; }      // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";      // Creature-0-4389-996-4799-62995-0008169144
    [LogField(6)] public string DestName { get; set; } = "";      // "Animated Protector"
    [LogField(7)] public long DestFlags { get; set; }      // 0xa48
    [LogField(8)] public long DestRaidFlags { get; set; }     // 0x80000000
    [LogField(9)] public long SpellId { get; set; }    // 76780
    [LogField(10)] public string SpellName { get; set; } = "";    // "Bind Elemental"
    [LogField(11)] public long SpellSchool { get; set; }       // 0x8
    [LogField(12)] public long BreakingSpellId { get; set; }     // 63468
    [LogField(13)] public string BreakingSpellName { get; set; } = "";    // "Piercing Shots"
    [LogField(14)] public long BreakingSpellSchool { get; set; }     // 1
    [LogField(15)] public string AuraType { get; set; } = "";    // DEBUFF
}