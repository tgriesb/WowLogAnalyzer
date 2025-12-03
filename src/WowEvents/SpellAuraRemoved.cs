using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellAuraRemoved : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_AURA_REMOVED;

    [LogField(1)] public string SourceGUID { get; set; } = "";    // Player-4395-02110D4F
    [LogField(2)] public string SourceName { get; set; } = "";    // "Hsojie-Whitemane-US"
    [LogField(3)] public long SourceFlags { get; set; }      // 0x80000512
    [LogField(4)] public long SourceRaidFlags { get; set; }      // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";      // Creature-0-4390-720-14930-53640-00006F25E2
    [LogField(6)] public string DestName { get; set; } = "";      // "Flamewaker Sentinel"
    [LogField(7)] public long DestFlags { get; set; }      // 0x80010a48
    [LogField(8)] public long DestRaidFlags { get; set; }     // 0x80000000
    [LogField(9)] public long SpellId { get; set; }    // 413841
    [LogField(10)] public string SpellName { get; set; } = "";    // "Ignite"
    [LogField(11)] public long SpellSchool { get; set; }       // 0x4
    [LogField(12)] public string AuraType { get; set; } = "";      // DEBUFF

}