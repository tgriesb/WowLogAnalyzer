using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class DamageSplit : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.DAMAGE_SPLIT;
    [LogField(1)] public string SourceGUID { get; set; } = "";  // Player-4385-05E60F02
    [LogField(2)] public string SourceName { get; set; } = "";  // "Holygran-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }    // 0x40512
    [LogField(4)] public int SourceRaidFlags { get; set; }    // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";    // Player-4385-05E528FE
    [LogField(6)] public string DestName { get; set; } = "";    // "Ugali-Immerseus-US"
    [LogField(7)] public int DestFlags { get; set; }    // 0x40511
    [LogField(8)] public int DestRaidFlags { get; set; }   // 0x80000000
    [LogField(9)] public int SpellId { get; set; }  // 6940
    [LogField(10)] public string SpellName { get; set; } = "";  // "Hand of Sacrifice"
    [LogField(11)] public int SpellSchool { get; set; }     // 0x2
    [LogField(12)] public string UnitGUID { get; set; } = "";  // Player-4385-05E528FE
    [LogField(13)] public string OwnerGUID { get; set; } = "";   // 0000000000000000
    [LogField(14)] public int CurrentHP { get; set; }  // 82
    [LogField(15)] public double MaxHP { get; set; }     // 100
    [LogField(16)] public double AttackPower { get; set; }  // 163045
    [LogField(17)] public double SpellPower { get; set; }     // 189
    [LogField(18)] public double Armor { get; set; }   // 58511
    [LogField(19)] public int TotalDamageAbsorbs { get; set; }    // 0
    [LogField(20)] public int ResourceType { get; set; }   // 0
    [LogField(21)] public int CurrentResource { get; set; }     // 0
    [LogField(22)] public int MaxResource { get; set; }     // 55800
    [LogField(23)] public int ResourceCost { get; set; }     // 60000
    [LogField(24)] public int ResourceCostUnknownFlag { get; set; }     // 0
    [LogField(25)] public float CordinateX { get; set; }     // -1025.94
    [LogField(26)] public float CordinateY { get; set; }     // -3048.01
    [LogField(27)] public int MapId { get; set; }     // 456
    [LogField(28)] public double Facing { get; set; }     // 2.2108
    [LogField(29)] public int ItemLvl { get; set; }     // 514
    [LogField(30)] public double Amount { get; set; }     // 8233
    [LogField(31)] public double Overkill { get; set; }     // 0
    [LogField(32)] public int School { get; set; }     // -1
    [LogField(33)] public double Resisted { get; set; }     // 1
    [LogField(34)] public double Blocked { get; set; }     // 0
    [LogField(35)] public double Absorbed { get; set; }     // 0
    [LogField(36)] public bool Critical { get; set; }     // 0
    [LogField(37)] public bool Glancing { get; set; }     // nil
    [LogField(38)] public bool Crushing { get; set; }     // nil
    [LogField(39)] public bool IsOffHand { get; set; }     // nil
    [LogField(40)] public bool DamageType { get; set; }    // ST
}