using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellInterrupt : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_INTERRUPT;

    [LogField(1)] public string SourceGUID { get; set; } = "";      // Player-4385-05E528FE
    [LogField(2)] public string SourceName { get; set; } = "";      // "Ugali-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }        // 0x40511
    [LogField(4)] public int SourceRaidFlags { get; set; }        // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";        // Vehicle-0-4389-996-4799-60585-00001687E9
    [LogField(6)] public string DestName { get; set; } = "";        // "Elder Regail"
    [LogField(7)] public int DestFlags { get; set; }        // 0x10a48
    [LogField(8)] public int DestRaidFlags { get; set; }       // 0x80000080
    [LogField(9)] public int SpellId { get; set; }      // 31935
    [LogField(10)] public string SpellName { get; set; } = "";      // "Avenger's Shield"
    [LogField(11)] public int SpellSchool { get; set; }         // 0x2
    [LogField(12)] public int InterruptedSpellId { get; set; }      // 117187
    [LogField(13)] public string InterruptedSpellName { get; set; } = "";       // "Lightning Bolt"
    [LogField(14)] public int InterruptedSpellSchool { get; set; }      // 8
}