using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellAuraRemovedDose : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_AURA_REMOVED_DOSE;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Player-4385-05E5E88C
    [LogField(2)] public string SourceName { get; set; } = "";       // "Kalleth-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }         // 0x514
    [LogField(4)] public int SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";         // Player-4385-05E60F02
    [LogField(6)] public string DestName { get; set; } = "";         // "Holygran-Immerseus-US"
    [LogField(7)] public int DestFlags { get; set; }         // 0x40512
    [LogField(8)] public int DestRaidFlags { get; set; }        // 0x80000000
    [LogField(9)] public int SpellId { get; set; }       // 974
    [LogField(10)] public string SpellName { get; set; } = "";       // "Earth Shield"
    [LogField(11)] public int SpellSchool { get; set; }          // 0x8
    [LogField(12)] public string AuraType { get; set; } = "";         // BUFF
    [LogField(13)] public int AuraDose { get; set; }    // 5
}