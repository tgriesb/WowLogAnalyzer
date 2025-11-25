using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellPeriodicDrain : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_PERIODIC_DRAIN;

    [LogField(1)] public string SourceGUID { get; set; } = "";      // Creature-0-4379-564-17507-23402-0001FAFA96
    [LogField(2)] public string SourceName { get; set; } = "";      // "Illidari Battle-mage"
    [LogField(3)] public int SourceFlags { get; set; }        // 0x80000a48
    [LogField(4)] public int SourceRaidFlags { get; set; }        // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";        // Player-4395-03C1264B
    [LogField(6)] public string DestName { get; set; } = "";        // "Ugali-Whitemane-US"
    [LogField(7)] public int DestFlags { get; set; }        // 0x80000511
    [LogField(8)] public int DestRaidFlags { get; set; }       // 0x80000000
    [LogField(9)] public int SpellId { get; set; }      // 41382
    [LogField(10)] public string SpellName { get; set; } = "";      // "Blizzard"
    [LogField(11)] public int SpellSchool { get; set; }         // 0x10
    [LogField(12)] public string UnitGUID { get; set; } = "";      // Player-4395-03C1264B
    [LogField(13)] public string OwnerGUID { get; set; } = "";       // 0000000000000000
    [LogField(14)] public int CurrentHP { get; set; }      // 75
    [LogField(15)] public double MaxHP { get; set; }         // 100
    [LogField(16)] public double AttackPower { get; set; }      // 15447
    [LogField(17)] public double SpellPower { get; set; }         // 112
    [LogField(18)] public double Armor { get; set; }       // 23452
    [LogField(19)] public int TotalDamageAbsorbs { get; set; }        // 0
    [LogField(20)] public int ResourceType { get; set; }       // 0
    [LogField(21)] public int CurrentResource { get; set; }         // 0
    [LogField(22)] public int MaxResource { get; set; }         // 19093
    [LogField(23)] public int ResourceCost { get; set; }         // 20000
    [LogField(24)] public int ResourceCostUnknownFlag { get; set; }         // 0
    [LogField(25)] public float CordinateX { get; set; }         // 558.64
    [LogField(26)] public float CordinateY { get; set; }         // 309.72
    [LogField(27)] public int MapId { get; set; }         // 345
    [LogField(28)] public double Facing { get; set; }         // 3.5210
    [LogField(29)] public int ItemLvl { get; set; }         // 404
    [LogField(30)] public double Amount { get; set; }         // 750
    [LogField(31)] public double Overkill { get; set; }         // 0
    [LogField(32)] public int School { get; set; }         // 0
    [LogField(33)] public double Resisted { get; set; }         // 20000
   
}