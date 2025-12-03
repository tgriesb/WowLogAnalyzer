using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellAuraAppliedDose : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_AURA_APPLIED_DOSE;

    [LogField(1)] public string SourceGUID { get; set; } = "";    // Creature-0-4389-996-4799-62983-0000168F94
    [LogField(2)] public string SourceName { get; set; } = "";    // "Lei Shi"
    [LogField(3)] public long SourceFlags { get; set; }      // 0x10a48
    [LogField(4)] public long SourceRaidFlags { get; set; }      // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";      // Player-4385-05E60F02
    [LogField(6)] public string DestName { get; set; } = "";      // "Holygran-Immerseus-US"
    [LogField(7)] public long DestFlags { get; set; }      // 0x40512
    [LogField(8)] public long DestRaidFlags { get; set; }     // 0x80000000
    [LogField(9)] public long SpellId { get; set; }    // 123121
    [LogField(10)] public string SpellName { get; set; } = "";    // "Spray"
    [LogField(11)] public long SpellSchool { get; set; }       // 0x10
    [LogField(12)] public string AuraType { get; set; } = "";    // DEBUFF
    [LogField(13)] public string AuraDose { get; set; } = "";    // 2 
}