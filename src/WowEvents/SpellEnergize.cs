using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellEnergize : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_ENERGIZE;

    [LogField(1)] public string SourceGUID { get; set; } = "";          // Player-4385-05E528FE
    [LogField(2)] public string SourceName { get; set; } = "";          // "Ugali-Immerseus-US"
    [LogField(3)] public long SourceFlags { get; set; }          // 0x511
    [LogField(4)] public long SourceRaidFlags { get; set; }          // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";            // Player-4385-05E528FE
    [LogField(6)] public string DestName { get; set; } = "";            // "Ugali-Immerseus-US"
    [LogField(7)] public long DestFlags { get; set; }            // 0x511
    [LogField(8)] public long DestRaidFlags { get; set; }            // 0x80000000
    [LogField(9)] public long SpellId { get; set; }          // 111528
    [LogField(10)] public string SpellName { get; set; } = "";          // "Judgments of the Bold"
    [LogField(11)] public long SpellSchool { get; set; }             // 0x1
    [LogField(12)] public string UnitGUID { get; set; } = "";           // Player-4385-05E528FE
    [LogField(13)] public string OwnerGUID { get; set; } = "";          // 0000000000000000
    [LogField(14)] public long CurrentHP { get; set; }           // 100
    [LogField(15)] public double MaxHP { get; set; }            // 100
    [LogField(16)] public double AttackPower { get; set; }          // 31344
    [LogField(17)] public double SpellPower { get; set; }           // 180
    [LogField(18)] public double Armor { get; set; }            // 33806
    [LogField(19)] public long TotalDamageAbsorbs { get; set; }          // 0
    [LogField(20)] public long ResourceType { get; set; }            // 0
    [LogField(21)] public long CurrentResource { get; set; }             // 0
    [LogField(22)] public long MaxResource { get; set; }             // 60000
    [LogField(23)] public long ResourceCost { get; set; }            // 60000
    [LogField(24)] public long ResourceCostUnknownFlag { get; set; }             // 0
    [LogField(25)] public float CordinateX { get; set; }             // 643.72
    [LogField(26)] public float CordinateY { get; set; }             // 920.61
    [LogField(27)] public long MapId { get; set; }              // 339
    [LogField(28)] public double Facing { get; set; }           // 5.9947
    [LogField(29)] public long ItemLvl { get; set; }             // 505
    [LogField(30)] public double Amount { get; set; }              // 1.0000
    [LogField(31)] public double OverEnergize { get; set; }              // 0.0000
    [LogField(32)] public long PowerType { get; set; }            // 9
    [LogField(33)] public long AlternatePowerType { get; set; }          // 5
}