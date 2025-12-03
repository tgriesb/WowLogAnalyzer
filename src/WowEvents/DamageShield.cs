using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class DamageShield : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.DAMAGE_SHIELD;

    [LogField(1)] public string SourceGUID { get; set; } = "";
    [LogField(2)] public string SourceName { get; set; } = "";
    [LogField(3)] public long SourceFlags { get; set; }
    [LogField(4)] public long SourceRaidFlags { get; set; }
    [LogField(5)] public string DestGUID { get; set; } = "";
    [LogField(6)] public string DestName { get; set; } = "";
    [LogField(7)] public long DestFlags { get; set; }
    [LogField(8)] public long DestRaidFlags { get; set; }
    [LogField(9)] public long SpellId { get; set; }
    [LogField(10)] public string SpellName { get; set; } = "";
    [LogField(11)] public long SpellSchool { get; set; }
    [LogField(12)] public double Amount { get; set; }
    [LogField(13)] public double Overkill { get; set; }
    [LogField(14)] public long School { get; set; }
    [LogField(15)] public double Resisted { get; set; }
    [LogField(16)] public double Blocked { get; set; }
    [LogField(17)] public double Absorbed { get; set; }
    [LogField(18)] public bool Critical { get; set; }
    [LogField(19)] public bool Glaring { get; set; }
    [LogField(20)] public bool Crushing { get; set; }
    [LogField(21)] public bool IsOffHand { get; set; }
}