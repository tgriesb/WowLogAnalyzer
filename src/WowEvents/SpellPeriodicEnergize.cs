using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellPeriodicEnergize : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_PERIODIC_ENERGIZE;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Player-4385-05E55270
    [LogField(2)] public string SourceName { get; set; } = "";       // "Snippss-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }         // 0x512
    [LogField(4)] public int SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";         // Player-4385-05E55270
    [LogField(6)] public string DestName { get; set; } = "";         // "Snippss-Immerseus-US"
    [LogField(7)] public int DestFlags { get; set; }         // 0x512
    [LogField(8)] public int DestRaidFlags { get; set; }        // 0x80000000
    [LogField(9)] public int SpellId { get; set; }       // 82726
    [LogField(10)] public string SpellName { get; set; } = "";       // "Fervor"
    [LogField(11)] public int SpellSchool { get; set; }          // 0x1
    [LogField(12)] public string UnitGUID { get; set; } = "";       // Player-4385-05E55270
    [LogField(13)] public string OwnerGUID { get; set; } = "";        // 0000000000000000
    [LogField(14)] public int CurrentHP { get; set; }       // 100
    [LogField(15)] public double MaxHP { get; set; }          // 100
    [LogField(16)] public double AttackPower { get; set; }       // 104562
    [LogField(17)] public double SpellPower { get; set; }          // 181
    [LogField(18)] public double Armor { get; set; }        // 25316
    [LogField(19)] public int TotalDamageAbsorbs { get; set; }         // 0
    [LogField(20)] public int ResourceType { get; set; }        // 0
    [LogField(21)] public int CurrentResource { get; set; }          // 2
    [LogField(22)] public int MaxResource { get; set; }          // 37
    [LogField(23)] public int ResourceCost { get; set; }          // 100
    [LogField(24)] public int ResourceCostUnknownFlag { get; set; }          // 0
    [LogField(25)] public float CordinateX { get; set; }          // -1014.20
    [LogField(26)] public float CordinateY { get; set; }          // -3018.82
    [LogField(27)] public int MapId { get; set; }          // 456
    [LogField(28)] public double Facing { get; set; }          // 4.6834
    [LogField(29)] public int ItemLvl { get; set; }          // 506
    [LogField(30)] public double Amount { get; set; }          // 5.0000
    [LogField(31)] public double Overkill { get; set; }          // 0.0000
    [LogField(32)] public int School { get; set; }          // 2
    [LogField(33)] public double Resisted { get; set; }          // 100  
}