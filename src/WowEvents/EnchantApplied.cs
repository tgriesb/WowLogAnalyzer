using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class EnchantApplied : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.ENCHANT_APPLIED;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Player-4395-03C1264B
    [LogField(2)] public string SourceName { get; set; } = "";       // "Ugali-Whitemane-US"
    [LogField(3)] public long SourceFlags { get; set; }       // 0x511
    [LogField(4)] public long SourceRaidFlags { get; set; }       // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";       // Player-4395-03C1264B
    [LogField(6)] public string DestName { get; set; } = "";       // "Ugali-Whitemane-US"
    [LogField(7)] public long DestFlags { get; set; }       // 0x511
    [LogField(8)] public long DestRaidFlags { get; set; }       // 0x80000000
    [LogField(9)] public string EnchantName { get; set; } = "";      // "Windsong"
    [LogField(10)] public long ItemId { get; set; }       // 84791
    [LogField(11)] public string ItemName { get; set; } = "";      // "Malevolent Gladiator's Decapitator"
}