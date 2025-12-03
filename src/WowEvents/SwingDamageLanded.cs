using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SwingDamageLanded : ICombatEvent, ISourceDestCombatEvent, IDamageCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SWING_DAMAGE_LANDED;

    [LogField(1)] public string SourceGUID { get; set; } = "";          // Player-4385-05E6580C    //  Player-4385-05E6580C
    [LogField(2)] public string SourceName { get; set; } = "";          // "Heathedger-Immerseus-US"    //  ""Heathedger-Immerseus-US""
    [LogField(3)] public long SourceFlags { get; set; }            // 0x512    //  0x512
    [LogField(4)] public long SourceRaidFlags { get; set; }            // 0x80000000    //  0x80000000
    [LogField(5)] public string DestGUID { get; set; } = "";            // Vehicle-0-4389-996-4799-60585-00001687E9    //  Creature-0-4392-1009-10294-64338-00001E83B5
    [LogField(6)] public string DestName { get; set; } = "";            // "Elder Regail"    //  ""Instructor Kli'thak""
    [LogField(7)] public long DestFlags { get; set; }            // 0x10a48    //  0xa48
    [LogField(8)] public long DestRaidFlags { get; set; }               // 0x80000080    //  0x80000000
    [LogField(9)] public string UnitGUID { get; set; } = "";          // Vehicle-0-4389-996-4799-60585-00001687E9    //  12288
    [LogField(10)] public string OwnerGUID { get; set; } = "";           // 0000000000000000    //  8946
    [LogField(11)] public long CurrentHP { get; set; }          // 91394437    //  -1
    [LogField(12)] public double MaxHP { get; set; }             // 91588770    //  1
    [LogField(13)] public double AttackPower { get; set; }          // 0    //  0
    [LogField(14)] public double SpellPower { get; set; }             // 0    //  0
    [LogField(15)] public double Armor { get; set; }           // 0    //  0
    [LogField(16)] public long TotalDamageAbsorbs { get; set; }            // 0    //  1
    [LogField(17)] public long ResourceType { get; set; }           // 0    //  nil
    [LogField(18)] public long CurrentResource { get; set; }             // -1    //  nil
    [LogField(19)] public long MaxResource { get; set; }             // 0
    [LogField(20)] public long ResourceCost { get; set; }             // 0
    [LogField(21)] public long ResourceCostUnknownFlag { get; set; }             // 0
    [LogField(22)] public float CordinateX { get; set; }             // -1009.94
    [LogField(23)] public float CordinateY { get; set; }             // -3045.02
    [LogField(24)] public long MapId { get; set; }             // 456
    [LogField(25)] public double Facing { get; set; }             // 1.9595
    [LogField(26)] public long ItemLvl { get; set; }             // 93
    [LogField(27)] public double Amount { get; set; }             // 10650
    [LogField(28)] public double Overkill { get; set; }             // 16368
    [LogField(29)] public long School { get; set; }             // -1
    [LogField(30)] public double Resisted { get; set; }             // 1
    [LogField(31)] public double Blocked { get; set; }             // 0
    [LogField(32)] public double Absorbed { get; set; }             // 0
    [LogField(33)] public bool Critical { get; set; }             // 0
    [LogField(34)] public bool Glancing { get; set; }             // nil
    [LogField(35)] public bool Crushing { get; set; }             // nil
    [LogField(36)] public bool IsOffHand { get; set; }             // nil


    //TODO:  11/19/2025 21:12:34.152-6  SWING_DAMAGE_LANDED,Player-4385-05E6580C,""Heathedger-Immerseus-US"",0x512,0x80000000,Creature-0-4392-1009-10294-64338-00001E83B5,""Instructor Kli'thak"",0xa48,0x80000000,12288,8946,-1,1,0,0,0,1,nil,nil

}