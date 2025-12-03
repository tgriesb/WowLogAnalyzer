using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellMissed : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_MISSED;

    [LogField(1)] public string SourceGUID { get; set; } = "";     // Player-4385-05E52D32
    [LogField(2)] public string SourceName { get; set; } = "";     // "Craigxecute-Immerseus-US"
    [LogField(3)] public long SourceFlags { get; set; }       // 0x512
    [LogField(4)] public long SourceRaidFlags { get; set; }       // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";       // Vehicle-0-4389-996-4799-60585-00001687E9
    [LogField(6)] public string DestName { get; set; } = "";       // "Elder Regail"
    [LogField(7)] public long DestFlags { get; set; }       // 0x10a48
    [LogField(8)] public long DestRaidFlags { get; set; }      // 0x80000080
    [LogField(9)] public long SpellId { get; set; }     // 7922
    [LogField(10)] public string SpellName { get; set; } = "";     // "Charge Stun"
    [LogField(11)] public long SpellSchool { get; set; }        // 0x1
    [LogField(12)] public string MissType { get; set; } = "";   // IMMUNE
    [LogField(13)] public string PowerType { get; set; } = "";      // nil
    [LogField(14)] public string DamageType { get; set; } = "";    // ST
}