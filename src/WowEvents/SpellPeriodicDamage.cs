using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellPeriodicDamage : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_PERIODIC_DAMAGE;

    [LogField(1)] public string SourceGUID { get; set; } = "";     // Player-4385-05E74D63
    [LogField(2)] public string SourceName { get; set; } = "";     // "Spiraled-Immerseus-US"
    [LogField(3)] public long SourceFlags { get; set; }       // 0x514
    [LogField(4)] public long SourceRaidFlags { get; set; }       // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";       // Vehicle-0-4389-996-4799-60585-00001687E9
    [LogField(6)] public string DestName { get; set; } = "";       // "Elder Regail"
    [LogField(7)] public long DestFlags { get; set; }       // 0x10a48
    [LogField(8)] public long DestRaidFlags { get; set; }      // 0x80000080
    [LogField(9)] public long SpellId { get; set; }     // 8921
    [LogField(10)] public string SpellName { get; set; } = "";     // "Moonfire"
    [LogField(11)] public long SpellSchool { get; set; }        // 0x40
    [LogField(12)] public string UnitGUID { get; set; } = "";     // Vehicle-0-4389-996-4799-60585-00001687E9
    [LogField(13)] public string OwnerGUID { get; set; } = "";      // 0000000000000000
    [LogField(14)] public long CurrentHP { get; set; }     // 91262475
    [LogField(15)] public double MaxHP { get; set; }        // 91588770
    [LogField(16)] public double AttackPower { get; set; }     // 0
    [LogField(17)] public double SpellPower { get; set; }        // 0
    [LogField(18)] public double Armor { get; set; }      // 0
    [LogField(19)] public long TotalDamageAbsorbs { get; set; }       // 0
    [LogField(20)] public long ResourceType { get; set; }      // 0
    [LogField(21)] public long CurrentResource { get; set; }        // -1
    [LogField(22)] public long MaxResource { get; set; }        // 0
    [LogField(23)] public long ResourceCost { get; set; }        // 0
    [LogField(24)] public long ResourceCostUnknownFlag { get; set; }        // 0
    [LogField(25)] public float CordinateX { get; set; }        // -1011.35
    [LogField(26)] public float CordinateY { get; set; }        // -3045.40
    [LogField(27)] public long MapId { get; set; }        // 456
    [LogField(28)] public double Facing { get; set; }        // 3.4068
    [LogField(29)] public long ItemLvl { get; set; }        // 93
    [LogField(30)] public double Amount { get; set; }        // 26988
    [LogField(31)] public double Overkill { get; set; }        // 12476
    [LogField(32)] public long School { get; set; }        // -1
    [LogField(33)] public double Resisted { get; set; }        // 64
    [LogField(34)] public double Blocked { get; set; }        // 0
    [LogField(35)] public double Absorbed { get; set; }        // 0
    [LogField(36)] public bool Critical { get; set; }        // 0
    [LogField(37)] public bool Glancing { get; set; }        // 1
    [LogField(38)] public bool Crushing { get; set; }        // nil
    [LogField(39)] public bool IsOffHand { get; set; }        // nil
    [LogField(40)] public bool DamageType { get; set; }       // ST
}