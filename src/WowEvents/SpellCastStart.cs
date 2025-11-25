using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellCastStart : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_CAST_START;

    [LogField(1)] public string SourceGUID { get; set; } = "";        // Player-4395-022B9D6A
    [LogField(2)] public string SourceName { get; set; } = "";        // "Jiglyball-Whitemane-US"
    [LogField(3)] public int SourceFlags { get; set; }          // 0x514
    [LogField(4)] public int SourceRaidFlags { get; set; }          // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";          // 0000000000000000
    [LogField(6)] public string DestName { get; set; } = "";          // nil
    [LogField(7)] public int DestFlags { get; set; }          // 0x80000000
    [LogField(8)] public int DestRaidFlags { get; set; }         // 0x80000000
    [LogField(9)] public int SpellId { get; set; }        // 20707
    [LogField(10)] public string SpellName { get; set; } = "";        // "Soulstone"
    [LogField(11)] public int SpellSchool { get; set; }           // 0x20
}