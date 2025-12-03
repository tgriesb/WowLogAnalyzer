using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellCastFailed : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_CAST_FAILED;

    [LogField(1)] public string SourceGUID { get; set; } = "";         // Player-4395-03C1264B
    [LogField(2)] public string SourceName { get; set; } = "";         // "Ugali-Whitemane-US"
    [LogField(3)] public long SourceFlags { get; set; }           // 0x40511
    [LogField(4)] public long SourceRaidFlags { get; set; }           // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";           // 0000000000000000
    [LogField(6)] public string DestName { get; set; } = "";           // nil
    [LogField(7)] public long DestFlags { get; set; }           // 0x80000000
    [LogField(8)] public long DestRaidFlags { get; set; }          // 0x80000000
    [LogField(9)] public long SpellId { get; set; }         // 84751
    [LogField(10)] public string SpellName { get; set; } = "";         // "Fossilized Raptor"
    [LogField(11)] public long SpellSchool { get; set; }            // 0x1
    [LogField(12)] public string FailMessage { get; set; } = "";   // "Another action is in progress"
}