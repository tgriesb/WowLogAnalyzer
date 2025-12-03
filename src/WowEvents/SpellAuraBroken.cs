using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellAuraBroken : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_AURA_BROKEN;

    [LogField(1)] public string SourceGUID { get; set; } = "";    // 0000000000000000
    [LogField(2)] public string SourceName { get; set; } = "";    // nil
    [LogField(3)] public long SourceFlags { get; set; }      // 0x80000000
    [LogField(4)] public long SourceRaidFlags { get; set; }      // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";      // Player-4385-05E62478
    [LogField(6)] public string DestName { get; set; } = "";      // "SomePlayer-LeiShen-US"
    [LogField(7)] public long DestFlags { get; set; }      // 0x518
    [LogField(8)] public long DestRaidFlags { get; set; }     // 0x80000000
    [LogField(9)] public long SpellId { get; set; }    // 546
    [LogField(10)] public string SpellName { get; set; } = "";    // "Water Walking"
    [LogField(11)] public long SpellSchool { get; set; }       // 0x8
    [LogField(12)] public string AuraType { get; set; } = "";    // BUFF
}