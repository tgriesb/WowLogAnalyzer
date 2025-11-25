using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellInstakill : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_INSTAKILL;

    [LogField(1)] public string SourceGUID { get; set; } = "";      // Player-4385-05E55B5C
    [LogField(2)] public string SourceName { get; set; } = "";      // "Jiglyball-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }        // 0x514
    [LogField(4)] public int SourceRaidFlags { get; set; }        // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";        // Pet-0-4389-996-4799-416-0100C3170C
    [LogField(6)] public string DestName { get; set; } = "";        // "Abatuk"
    [LogField(7)] public int DestFlags { get; set; }        // 0x1114
    [LogField(8)] public int DestRaidFlags { get; set; }       // 0x80000000
    [LogField(9)] public int SpellId { get; set; }      // 108503
    [LogField(10)] public string SpellName { get; set; } = "";      // "Grimoire of Sacrifice"
    [LogField(11)] public int SpellSchool { get; set; }         // 0x20
    [LogField(12)] public int PlaceHolder12 { get; set; }      // 0
}