using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellDrain : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_DRAIN;

    [LogField(1)] public string SourceGUID { get; set; } = "";       // Vehicle-0-4378-1008-3809-60009-000014199F
    [LogField(2)] public string SourceName { get; set; } = "";       // "Feng the Accursed"
    [LogField(3)] public long SourceFlags { get; set; }         // 0x80010a48
    [LogField(4)] public long SourceRaidFlags { get; set; }         // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";         // Player-4395-03C1264B
    [LogField(6)] public string DestName { get; set; } = "";         // "Ugali-Whitemane-US"
    [LogField(7)] public long DestFlags { get; set; }         // 0x80040511
    [LogField(8)] public long DestRaidFlags { get; set; }        // 0x80000000
    [LogField(9)] public long SpellId { get; set; }       // 118783
    [LogField(10)] public string SpellName { get; set; } = "";       // "Chains of Shadow"
    [LogField(11)] public long SpellSchool { get; set; }          // 0x20
    [LogField(12)] public string UnitGUID { get; set; } = "";       // Player-4395-03C1264B
    [LogField(13)] public string OwnerGUID { get; set; } = "";        // 0000000000000000
    [LogField(14)] public long CurrentHP { get; set; }       // 97
    [LogField(15)] public double MaxHP { get; set; }          // 100
    [LogField(16)] public double AttackPower { get; set; }       // 87564
    [LogField(17)] public double SpellPower { get; set; }          // 105
    [LogField(18)] public double Armor { get; set; }        // 53854
    [LogField(19)] public long TotalDamageAbsorbs { get; set; }         // 0
    [LogField(20)] public long ResourceType { get; set; }        // 0
    [LogField(21)] public long CurrentResource { get; set; }          // 0
    [LogField(22)] public long MaxResource { get; set; }          // 58203
    [LogField(23)] public long ResourceCost { get; set; }          // 60000
    [LogField(24)] public long ResourceCostUnknownFlag { get; set; }          // 0
    [LogField(25)] public float CordinateX { get; set; }          // 4043.11
    [LogField(26)] public float CordinateY { get; set; }          // 1342.65
    [LogField(27)] public long MapId { get; set; }          // 471
    [LogField(28)] public double Facing { get; set; }          // 4.6006
    [LogField(29)] public long ItemLvl { get; set; }          // 477
    [LogField(30)] public double Amount { get; set; }          // 3000
    [LogField(31)] public double Overkill { get; set; }          // 0
    [LogField(32)] public long Extra { get; set; }          // 0
    [LogField(33)] public double Gained { get; set; }          // 60000    
}