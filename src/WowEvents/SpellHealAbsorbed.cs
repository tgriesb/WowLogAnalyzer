using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellHealAbsorbed : ICombatEvent, ISourceDestCombatEvent, IAbsorbCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_HEAL_ABSORBED;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Vehicle-0-4411-1009-3989-62847-000
    [LogField(2)] public string SourceName { get; set; } = "";       // "Dissonance Field"
    [LogField(3)] public long SourceFlags { get; set; }         // 0xa48
    [LogField(4)] public long SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";         // Player-4385-05E54EFC
    [LogField(6)] public string DestName { get; set; } = "";         // "Hsojie-Immerseus-US"
    [LogField(7)] public long DestFlags { get; set; }         // 0x514
    [LogField(8)] public long DestRaidFlags { get; set; }        // 0x80000000
    [LogField(9)] public long SpellId { get; set; }       // 123184
    [LogField(10)] public string SpellName { get; set; } = "";       // "Dissonance Field"
    [LogField(11)] public long SpellSchool { get; set; }          // 0x1
    [LogField(12)] public string HealerGUID { get; set; } = "";       // Player-4385-05E5E88C
    [LogField(13)] public string HealerName { get; set; } = "";        // "Kalleth-Immerseus-US"
    [LogField(14)] public long HealerFlags { get; set; }       // 0x514
    [LogField(15)] public long HealerRaidFlags { get; set; }          // 0x80000000
    [LogField(16)] public long HealSpellId { get; set; }       // 52042
    [LogField(17)] public string HealSpellName { get; set; } = "";      // "Healing Stream Totem"
    [LogField(18)] public  long HealSpellSchool { get; set; }       // 0x8
    [LogField(19)] public double Amount { get; set; }         // 39146
    [LogField(20)] public long OriginalHealAmount { get; set; }        // 39146
}