using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellCastSuccess : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_CAST_SUCCESS;

    [LogField(1)] public string SourceGUID { get; set; } = "";     // Player-4385-05E5E88C
    [LogField(2)] public string SourceName { get; set; } = "";     // "Kalleth-Immerseus-US"
    [LogField(3)] public int SourceFlags { get; set; }       // 0x512
    [LogField(4)] public int SourceRaidFlags { get; set; }       // 0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";       // Player-4385-05E54138
    [LogField(6)] public string DestName { get; set; } = "";       // "Nepriesto-Immerseus-US"
    [LogField(7)] public int DestFlags { get; set; }       // 0x512
    [LogField(8)] public int DestRaidFlags { get; set; }      // 0x80000000
    [LogField(9)] public int SpellId { get; set; }     // 73680
    [LogField(10)] public string SpellName { get; set; } = "";     // "Unleash Elements"
    [LogField(11)] public int SpellSchool { get; set; }        // 0x8
    [LogField(12)] public string UnitGUID { get; set; } = "";     // Player-4385-05E5E88C
    [LogField(13)] public string OwnerGUID { get; set; } = "";      // 0000000000000000
    [LogField(14)] public int CurrentHP { get; set; }     // 100
    [LogField(15)] public double MaxHP { get; set; }        // 100
    [LogField(16)] public double AttackPower { get; set; }     // 700
    [LogField(17)] public double SpellPower { get; set; }        // 29224
    [LogField(18)] public double Armor { get; set; }      // 25304
    [LogField(19)] public int TotalDamageAbsorbs { get; set; }       // 0
    [LogField(20)] public int ResourceType { get; set; }      // 0
    [LogField(21)] public int CurrentResource { get; set; }        // 0
    [LogField(22)] public int MaxResource { get; set; }        // 300000
    [LogField(23)] public int ResourceCost { get; set; }        // 300000
    [LogField(24)] public int ResourceCostUnknownFlag { get; set; }        // 4920
    [LogField(25)] public float CordinateX { get; set; }        // -2204.73
    [LogField(26)] public float CordinateY { get; set; }        // 475.50
    [LogField(27)] public int MapId { get; set; }        // 475
    [LogField(28)] public double Facing { get; set; }        // 2.0504
    [LogField(29)] public int ItemLvl { get; set; }        // 508   
}