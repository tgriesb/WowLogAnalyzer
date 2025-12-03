using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellBuildingDamage : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_BUILDING_DAMAGE;

    [LogField(1)] public string SourceGUID { get; set; } = "";      // Vehicle-0-4379-603-8732-33109-0002476568
    [LogField(2)] public string SourceName { get; set; } = "";      // "Salvaged Demolisher"
    [LogField(3)] public long SourceFlags { get; set; }        // 0x1112
    [LogField(4)] public long SourceRaidFlags { get; set; }        // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";        // GameObject-0-4379-603-8732-194414-0000476565
    [LogField(6)] public string DestName { get; set; } = "";        // "Storm Beacon"
    [LogField(7)] public long DestFlags { get; set; }        // 0x4228
    [LogField(8)] public long DestRaidFlags { get; set; }       // 0x80000000
    [LogField(9)] public long SpellId { get; set; }      // 62307
    [LogField(10)] public string SpellName { get; set; } = "";      // "Boulder"
    [LogField(11)] public long SpellSchool { get; set; }         // 0x4
    [LogField(12)] public double Amount { get; set; }     // 2103
    [LogField(13)] public double Overkill { get; set; }      // 2103
    [LogField(14)] public long SchoolMask { get; set; }      // 0
    [LogField(15)] public long Resisted { get; set; }       // 4
    [LogField(16)] public long Blocked { get; set; }       // 0
    [LogField(17)] public long Absorbed { get; set; }       // 0
    [LogField(18)] public bool Critical { get; set; }       // 0
    [LogField(19)] public bool Glancing { get; set; }     // nil
    [LogField(20)] public bool Crushing { get; set; }     // nil
}
