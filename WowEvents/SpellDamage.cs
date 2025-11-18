using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellDamage : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_DAMAGE;

    [LogField(1)] public string SourceGUID { get; set; } = "";     // Player-4385-05E528FE
    [LogField(2)] public string SourceName { get; set; } = "";     // "Ugali-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }       // 0x40511
    [LogField(4)] public int SourceRaidFlags { get; set; }       // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";       // Creature-0-5549-1009-22686-64916-0000685358
    [LogField(6)] public string DestName { get; set; } = "";       // "Kor'thik Swarmguard"
    [LogField(7)] public int DestFlags { get; set; }       // 0x10a48
    [LogField(8)] public int DestRaidFlags { get; set; }      // 0x80000000
    [LogField(9)] public int SpellId { get; set; }     // 31935
    [LogField(10)] public string SpellName { get; set; } = "";     // "Avenger's Shield"
    [LogField(11)] public int SpellSchool { get; set; }        // 0x2
    [LogField(12)] public string UnitGUID { get; set; } = "";     // Creature-0-5549-1009-22686-64916-0000685358
    [LogField(13)] public string OwnerGUID { get; set; } = "";      // 0000000000000000
    [LogField(14)] public int CurrentHP { get; set; }     // 6281868
    [LogField(15)] public double MaxHP { get; set; }        // 6323880
    [LogField(16)] public double AttackPower { get; set; }     // 0
    [LogField(17)] public double SpellPower { get; set; }        // 0
    [LogField(18)] public double Armor { get; set; }      // 0
    [LogField(19)] public int TotalDamageAbsorbs { get; set; }       // 0
    [LogField(20)] public int ResourceType { get; set; }      // 0
    [LogField(21)] public int CurrentResource { get; set; }        // -1
    [LogField(22)] public int MaxResource { get; set; }        // 0
    [LogField(23)] public int ResourceCost { get; set; }        // 0
    [LogField(24)] public int ResourceCostUnknownFlag { get; set; }        // 0
    [LogField(25)] public float CordinateX { get; set; }        // -2271.78
    [LogField(26)] public float CordinateY { get; set; }        // 481.62
    [LogField(27)] public int MapId { get; set; }        // 475
    [LogField(28)] public double Facing { get; set; }        // 0.0000
    [LogField(29)] public int ItemLvl { get; set; }        // 92
    [LogField(30)] public double Amount { get; set; }        // 42012
    [LogField(31)] public double Overkill { get; set; }        // 42011
    [LogField(32)] public int School { get; set; }        // -1
    [LogField(33)] public double Resisted { get; set; }        // 2
    [LogField(34)] public double Blocked { get; set; }        // 0
    [LogField(35)] public double Absorbed { get; set; }        // 0
    [LogField(36)] public bool Critical { get; set; }        // 0
    [LogField(37)] public bool Glancing { get; set; }        // nil
    [LogField(38)] public bool Crushing { get; set; }        // nil
    [LogField(39)] public bool IsOffHand { get; set; }        // nil
    [LogField(40)] public bool DamageType { get; set; }       // ST

}