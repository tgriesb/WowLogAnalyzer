using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellExtraAttacks : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_EXTRA_ATTACKS;

    [LogField(1)] public string SourceGUID { get; set; } = "";         // Creature-0-5548-870-9-61006-0000142984
    [LogField(2)] public string SourceName { get; set; } = "";         // "Tankiss"
    [LogField(3)] public long SourceFlags { get; set; }         // 0x80000a48
    [LogField(4)] public long SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";           // Creature-0-5548-870-9-61006-0000142984
    [LogField(6)] public string DestName { get; set; } = "";           // "Tankiss"
    [LogField(7)] public long DestFlags { get; set; }           // 0x80000a48
    [LogField(8)] public long DestRaidFlags { get; set; }           // 0x80000000
    [LogField(9)] public long SpellId { get; set; }         // 32731
    [LogField(10)] public string SpellName { get; set; } = "";         // "Flay"
    [LogField(11)] public long SpellSchool { get; set; }            // 0x1
    [LogField(11)] public long ExtraAttacks { get; set; }            // 1

}