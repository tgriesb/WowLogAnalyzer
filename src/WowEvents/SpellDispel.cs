using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellDispel : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_DISPEL;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Player-4395-02129ECF
    [LogField(2)] public string SourceName { get; set; } = "";       // "Kalleths-Whitemane-US"
    [LogField(3)] public int SourceFlags { get; set; }         // 0x514
    [LogField(4)] public int SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";         // Player-4395-03EFD6FD
    [LogField(6)] public string DestName { get; set; } = "";         // "Heathedger-Whitemane-US"
    [LogField(7)] public int DestFlags { get; set; }         // 0x512
    [LogField(8)] public int DestRaidFlags { get; set; }        // 0x80000000
    [LogField(9)] public int SpellId { get; set; }       // 77130
    [LogField(10)] public string SpellName { get; set; } = "";       // "Purify Spirit"
    [LogField(11)] public int SpellSchool { get; set; }          // 0x8
    [LogField(12)] public int DispelledSpellId { get; set; }           // 121245
    [LogField(13)] public string DispelledSpellName { get; set; } = "";        // "Curse of Vitality"
    [LogField(14)] public int DispelledSpellSchool { get; set; }       // 32
    [LogField(15)] public string DispelledType { get; set; } = "";         // DEBUFF
}