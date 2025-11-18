using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellPeriodicMissed : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_PERIODIC_MISSED;


    [LogField(1)] public string SourceGUID { get; set; } = "";        // Player-4385-05E60F02                          // "Creature-0-4389-996-4799-62983-0000168F94"
    [LogField(2)] public string SourceName { get; set; } = "";        // "Holygran-Immerseus-US"                       // "Lei Shi"
    [LogField(3)] public int SourceFlags { get; set; }          // 0x40512                                             // "0x10a48"
    [LogField(4)] public int SourceRaidFlags { get; set; }          // 0x80000000                                      // "0x80000000"
    [LogField(5)] public string DestGUID { get; set; } = "";          // Player-4385-05E60F02                          // "93402"
    [LogField(6)] public string DestName { get; set; } = "";          // "Holygran-Immerseus-US"                       // "Sunfire"
    [LogField(7)] public int DestFlags { get; set; }          // 0x40512                                               // "0x8"
    [LogField(8)] public int DestRaidFlags { get; set; }         // 0x80000000                                         // "IMMUNE"
    [LogField(9)] public int SpellId { get; set; }        // 124255                                                    // "nil"
    [LogField(10)] public string SpellName { get; set; } = "";        // "Stagger"                                     // "ST"
    [LogField(11)] public int SpellSchool { get; set; }           // 0x1                           
    [LogField(12)] public string MissType { get; set; } = "";        // ABSORB
    [LogField(13)] public bool IsOffHand { get; set; }         // nil
    [LogField(14)] public double AmountMissed { get; set; }        // 18579
    [LogField(15)] public double amountFullTick { get; set; }           // 18578
    [LogField(16)] public string DamageType { get; set; } = "";         // ST    


    public string[] CleanFields(string[] fields)
    {
        // If there are 21 fields, no need for swaps
        if (fields.Length == 17)
        {
            return fields;
        }

        return [
            fields[0],
            fields[1],
            fields[2],
            fields[3],
            fields[4],
            fields[5],
            fields[6],
            fields[7],
            fields[8],
            fields[9],
            fields[10],
            fields[11],
            fields[12],
            "nil",
            "nil",
            fields[13],
            fields[14]
        ];
    }
}