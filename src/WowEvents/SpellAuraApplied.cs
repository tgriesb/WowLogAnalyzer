using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellAuraApplied : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_AURA_APPLIED;

    [LogField(1)] public string SourceGUID { get; set; } = "";    // Creature-0-4389-996-4799-62995-0002168F8F
    [LogField(2)] public string SourceName { get; set; } = "";    // "Animated Protector"
    [LogField(3)] public long SourceFlags { get; set; }      // 0xa48
    [LogField(4)] public long SourceRaidFlags { get; set; }      // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";      // Creature-0-4389-996-4799-62995-0002168F8F
    [LogField(6)] public string DestName { get; set; } = "";      // "Animated Protector"
    [LogField(7)] public long DestFlags { get; set; }      // 0xa48
    [LogField(8)] public long DestRaidFlags { get; set; }     // 0x80000000
    [LogField(9)] public long SpellId { get; set; }    // 123505
    [LogField(10)] public string SpellName { get; set; } = "";    // "Protect"
    [LogField(11)] public long SpellSchool { get; set; }       // 0x8
    [LogField(12)] public string AuraType { get; set; } = "";    // BUFF    
}