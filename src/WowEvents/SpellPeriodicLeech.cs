using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellPeriodicLeech : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_PERIODIC_LEECH;

    // TODO: No example, will have to circle back
    [LogField(1)] public string SourceGUID { get; set; } = "";           // Player-4385-05E5E88C
    [LogField(2)] public string SourceName { get; set; } = "";           // "Kalleth-Immerseus-US"
    [LogField(3)] public long SourceFlags { get; set; }             // 0x514
    [LogField(4)] public long SourceRaidFlags { get; set; }             // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";             // Player-4385-05E60F02
    [LogField(6)] public string DestName { get; set; } = "";             // "Holygran-Immerseus-US"
    [LogField(7)] public long DestFlags { get; set; }             // 0x40512
    [LogField(8)] public long DestRaidFlags { get; set; }            // 0x80000000
    [LogField(9)] public long SpellId { get; set; }           // 51945
    [LogField(10)] public string SpellName { get; set; } = "";           // "Earthliving"
    [LogField(11)] public long SpellSchool { get; set; }              // 0x8
    [LogField(12)] public string UnitGUID { get; set; } = "";           // Player-4385-05E60F02
    [LogField(13)] public string OwnerGUID { get; set; } = "";            // 0000000000000000
    [LogField(14)] public long CurrentHP { get; set; }           // 82
    [LogField(15)] public double MaxHP { get; set; }              // 100
    [LogField(16)] public double AttackPower { get; set; }           // 102706
    [LogField(17)] public double SpellPower { get; set; }              // 250
    [LogField(18)] public double Armor { get; set; }            // 18806
    [LogField(19)] public long TotalDamageAbsorbs { get; set; }             // 0
    [LogField(20)] public long ResourceType { get; set; }            // 0
    [LogField(21)] public long CurrentResource { get; set; }              // 3
    [LogField(22)] public long MaxResource { get; set; }              // 90
    [LogField(23)] public long ResourceCost { get; set; }              // 100
    [LogField(24)] public long ResourceCostUnknownFlag { get; set; }              // 0
    [LogField(25)] public float CordinateX { get; set; }              // -1010.23
    [LogField(26)] public float CordinateY { get; set; }              // -3042.49
    [LogField(27)] public long MapId { get; set; }              // 456
    [LogField(28)] public double Facing { get; set; }              // 4.4752
    [LogField(29)] public long ItemLvl { get; set; }              // 510
    [LogField(30)] public double Amount { get; set; }              // 6993
    [LogField(31)] public double UnmitigatedAmount { get; set; }          // 6993
    [LogField(32)] public double OverHeal { get; set; }        // 0
    [LogField(33)] public double Absorbed { get; set; }       // 0
    [LogField(33)] public bool Critical { get; set; }        // nil
}