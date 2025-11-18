using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class EnchantRemoved : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.ENCHANT_REMOVED;

    [LogField(1)] public string SourceGUID { get; set; } = "";      // 0000000000000000
    [LogField(2)] public string SourceName { get; set; } = "";      // nil
    [LogField(3)] public int SourceFlags { get; set; }      // 0x80000000
    [LogField(4)] public int SourceRaidFlags { get; set; }      // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";      // Player-4395-03C1264B
    [LogField(6)] public string DestName { get; set; } = "";      // "Ugali-Whitemane-US"
    [LogField(7)] public int DestFlags { get; set; }      // 0x80000511
    [LogField(8)] public int DestRaidFlags { get; set; }      // 0x80000000
    [LogField(9)] public string EnchantName { get; set; } = "";     // "+40 Expertise and +40 Mastery"
    [LogField(10)] public int ItemId { get; set; }      // 64676
    [LogField(11)] public string ItemName { get; set; } = "";     // "Unknown"
}