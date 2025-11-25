using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellCreate : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_CREATE;

    [LogField(1)] public string SourceGUID { get; set; } = "";     // Player-4395-022B9D6A
    [LogField(2)] public string SourceName { get; set; } = "";     // "Jiglyball-Whitemane-US"
    [LogField(3)] public int SourceFlags { get; set; }       // 0x514
    [LogField(4)] public int SourceRaidFlags { get; set; }       // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";       // GameObject-0-4378-996-25680-181621-00004CAE6F
    [LogField(6)] public string DestName { get; set; } = "";       // "Soulwell"
    [LogField(7)] public int DestFlags { get; set; }       // 0x4228
    [LogField(8)] public int DestRaidFlags { get; set; }      // 0x80000000
    [LogField(9)] public int SpellId { get; set; }     // 29893
    [LogField(10)] public string SpellName { get; set; } = "";     // "Create Soulwell"
    [LogField(11)] public int SpellSchool { get; set; }        // 0x20
}