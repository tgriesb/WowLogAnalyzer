using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellResurrect : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_RESURRECT;

    [LogField(1)] public string SourceGUID { get; set; } = "";     // Player-4385-05E55B5C
    [LogField(2)] public string SourceName { get; set; } = "";     // "Jiglyball-Immerseus-US"
    [LogField(3)] public long SourceFlags { get; set; }       // 0x514
    [LogField(4)] public long SourceRaidFlags { get; set; }       // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";       // Player-4385-05E528FE
    [LogField(6)] public string DestName { get; set; } = "";       // "Ugali-Immerseus-US"
    [LogField(7)] public long DestFlags { get; set; }       // 0x40511
    [LogField(8)] public long DestRaidFlags { get; set; }      // 0x80000000
    [LogField(9)] public long SpellId { get; set; }     // 95750
    [LogField(10)] public string SpellName { get; set; } = "";     // "Soulstone Resurrection"
    [LogField(11)] public long SpellSchool { get; set; }        // 0x20  

}