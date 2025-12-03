using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class EnvironmentalDamage : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.ENVIRONMENTAL_DAMAGE;


    [LogField(1)] public string SourceGUID { get; set; } = "";    // 0000000000000000
    [LogField(2)] public string SourceName { get; set; } = "";    // nil
    [LogField(3)] public long SourceFlags { get; set; }      // 0x80000000
    [LogField(4)] public long SourceRaidFlags { get; set; }      // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";      // Player-4385-05E5527
    [LogField(6)] public string DestName { get; set; } = "";      // "Snippss-Immerseus-
    [LogField(7)] public long DestFlags { get; set; }      // 0x512
    [LogField(8)] public long DestRaidFlags { get; set; }     // 0x80000000
    [LogField(9)] public string UnitGUID { get; set; } = "";    // Player-4385-05E5527
    [LogField(10)] public string OwnerGUID { get; set; } = "";     // 0000000000000000
    [LogField(11)] public long CurrentHP { get; set; }    // 78
    [LogField(12)] public double MaxHP { get; set; }       // 100
    [LogField(13)] public double AttackPower { get; set; }    // 95120
    [LogField(14)] public double SpellPower { get; set; }       // 181
    [LogField(15)] public double Armor { get; set; }     // 25412
    [LogField(16)] public long TotalDamageAbsorbs { get; set; }      // 0
    [LogField(17)] public long ResourceType { get; set; }     // 0
    [LogField(18)] public long CurrentResource { get; set; }       // 2
    [LogField(19)] public long MaxResource { get; set; }       // 47
    [LogField(20)] public long ResourceCost { get; set; }       // 100
    [LogField(21)] public long ResourceCostUnknownFlag { get; set; }       // 0
    [LogField(22)] public float CordinateX { get; set; }       // -1951.12
    [LogField(23)] public float CordinateY { get; set; }       // 474.76
    [LogField(24)] public long MapId { get; set; }       // 475
    [LogField(25)] public double Facing { get; set; }       // 0.0166
    [LogField(26)] public long ItemLvl { get; set; }       // 507
    [LogField(27)] public string DamageType { get; set; } = ""; // Falling
    [LogField(28)] public double Amount { get; set; }        // 47563
    [LogField(29)] public double Overkill { get; set; }       // 47563
    [LogField(30)] public long School { get; set; }      // 0
    [LogField(31)] public double Resisted { get; set; }       // 1
    [LogField(32)] public double Blocked { get; set; }        // 0
    [LogField(33)] public double Absorbed { get; set; }        // 0
    [LogField(34)] public bool Critical { get; set; }      // 0
    [LogField(35)] public bool Glancing { get; set; }       // nil
    [LogField(36)] public bool Crushing { get; set; }      // nil
    [LogField(37)] public bool IsOffHand { get; set; }     // nil
}  