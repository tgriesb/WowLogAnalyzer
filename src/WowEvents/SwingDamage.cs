using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SwingDamage : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SWING_DAMAGE;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Player-4385-05E6580C
    [LogField(2)] public string SourceName { get; set; } = "";       // "Heathedger-Immerseus-US"
    [LogField(3)] public long SourceFlags { get; set; }         // 0x512
    [LogField(4)] public long SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";         // Vehicle-0-4389-996-4799-60585-00001687E9
    [LogField(6)] public string DestName { get; set; } = "";         // "Elder Regail"
    [LogField(7)] public long DestFlags { get; set; }         // 0x10a48
    [LogField(8)] public long DestRaidFlags { get; set; }            // 0x80000080
    [LogField(9)] public string UnitGUID { get; set; } = "";       // Player-4385-05E6580C
    [LogField(10)] public string OwnerGUID { get; set; } = "";        // 0000000000000000
    [LogField(11)] public long CurrentHP { get; set; }       // 100
    [LogField(12)] public double MaxHP { get; set; }          // 100
    [LogField(13)] public double AttackPower { get; set; }       // 53098
    [LogField(14)] public double SpellPower { get; set; }          // 121
    [LogField(15)] public double Armor { get; set; }        // 18937
    [LogField(16)] public long TotalDamageAbsorbs { get; set; }         // 0
    [LogField(17)] public long ResourceType { get; set; }        // 0
    [LogField(18)] public long CurrentResource { get; set; }          // 3
    [LogField(19)] public long MaxResource { get; set; }          // 106
    [LogField(20)] public long ResourceCost { get; set; }          // 120
    [LogField(21)] public long ResourceCostUnknownFlag { get; set; }          // 0
    [LogField(22)] public float CordinateX { get; set; }          // -1009.07
    [LogField(23)] public float CordinateY { get; set; }          // -3046.82
    [LogField(24)] public long MapId { get; set; }          // 456
    [LogField(25)] public double Facing { get; set; }          // 2.0215
    [LogField(26)] public long ItemLvl { get; set; }          // 513
    [LogField(27)] public double Amount { get; set; }          // 10650
    [LogField(28)] public double Overkill { get; set; }          // 16368
    [LogField(29)] public long School { get; set; }          // -1
    [LogField(30)] public double Resisted { get; set; }          // 1
    [LogField(31)] public double Blocked { get; set; }          // 0
    [LogField(32)] public double Absorbed { get; set; }          // 0
    [LogField(33)] public bool Critical { get; set; }          // 0
    [LogField(34)] public bool Glancing { get; set; }          // nil
    [LogField(35)] public bool Crushing { get; set; }          // nil
    [LogField(36)] public bool IsOffHand { get; set; }          // nil
}