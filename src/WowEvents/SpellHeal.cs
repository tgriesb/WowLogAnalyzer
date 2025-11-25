using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellHeal : ICombatEvent, ISourceDestCombatEvent, IHealCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_HEAL;

    [LogField(1)] public string SourceGUID { get; set; } = "";           // Player-4385-05E5E88C
    [LogField(2)] public string SourceName { get; set; } = "";           // "Kalleth-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }             // 0x10514
    [LogField(4)] public int SourceRaidFlags { get; set; }             // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";             // Player-4385-05E60F02
    [LogField(6)] public string DestName { get; set; } = "";             // "Holygran-Immerseus-US"
    [LogField(7)] public int DestFlags { get; set; }             // 0x40512
    [LogField(8)] public int DestRaidFlags { get; set; }            // 0x80000000
    [LogField(9)] public int SpellId { get; set; }           // 73685
    [LogField(10)] public string SpellName { get; set; } = "";           // "Unleash Life"
    [LogField(11)] public int SpellSchool { get; set; }              // 0x8
    [LogField(12)] public string UnitGUID { get; set; } = "";           // Player-4385-05E60F02
    [LogField(13)] public string OwnerGUID { get; set; } = "";            // 0000000000000000
    [LogField(14)] public int CurrentHP { get; set; }           // 100
    [LogField(15)] public double MaxHP { get; set; }              // 100
    [LogField(16)] public double AttackPower { get; set; }           // 35417
    [LogField(17)] public double SpellPower { get; set; }              // 250
    [LogField(18)] public double Armor { get; set; }            // 18748
    [LogField(19)] public int TotalDamageAbsorbs { get; set; }             // 0
    [LogField(20)] public int ResourceType { get; set; }            // 0
    [LogField(21)] public int CurrentResource { get; set; }              // 3
    [LogField(22)] public int MaxResource { get; set; }              // 100
    [LogField(23)] public int ResourceCost { get; set; }              // 100
    [LogField(24)] public int ResourceCostUnknownFlag { get; set; }              // 0
    [LogField(25)] public float CordinateX { get; set; }              // -1017.36
    [LogField(26)] public float CordinateY { get; set; }              // -2832.50
    [LogField(27)] public int MapId { get; set; }              // 456
    [LogField(28)] public double Facing { get; set; }              // 1.5967
    [LogField(29)] public int ItemLvl { get; set; }              // 508
    [LogField(30)] public double Amount { get; set; }              // 20762
    [LogField(31)] public double UnmitigatedAmount { get; set; }          // 20762
    [LogField(32)] public double OverHeal { get; set; }        // 20762
    [LogField(33)] public double Absorbed { get; set; }       // 0
    [LogField(33)] public bool Critical { get; set; }        // nil
}