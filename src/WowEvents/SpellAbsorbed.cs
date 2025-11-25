using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellAbsorbed : ICombatEvent, ISourceDestCombatEvent, IAbsorbCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_ABSORBED;

    [LogField(1)] public string SourceGUID { get; set; } = "";      // Player-4385-05E60F02              // Vehicle-0-4389-996-4799-60583-00001687E9
    [LogField(2)] public string SourceName { get; set; } = "";      // "Holygran-Immerseus-US"           // "Protector Kaolan"
    [LogField(3)] public int SourceFlags { get; set; }              // 0x40512                           // 0xa48
    [LogField(4)] public int SourceRaidFlags { get; set; }          // 0x80000000                        // 0x80000020
    [LogField(5)] public string DestGUID { get; set; } = "";        // Player-4385-05E60F02              // Player-4385-05E60F02
    [LogField(6)] public string DestName { get; set; } = "";        // "Holygran-Immerseus-US"           // "Holygran-Immerseus-US"
    [LogField(7)] public int DestFlags { get; set; }                // 0x40512                           // 0x40512
    [LogField(8)] public int DestRaidFlags { get; set; }            // 0x80000000                        // 0x80000000



    [LogField(9)] public int SpellId { get; set; }                 // 124255                            // Player-4385-05E60F02
    [LogField(10)] public string SpellName { get; set; } = "";      // "Stagger"                         // "Holygran-Immerseus-US"
    [LogField(11)] public int SpellSchool { get; set; }             // 0x1                               // 0x40512
    [LogField(12)] public string UnitGUID { get; set; } = "";        // Player-4385-05E54138              // 0x80000000
    [LogField(13)] public string UnitName { get; set; } = "";       // "Nepriesto-Immerseus-US"          // 115069
    [LogField(14)] public int UnitFlags { get; set; }               // 0x514                             // "Stance of the Sturdy Ox"
    [LogField(15)] public int UnitRaidFlags { get; set; }           // 0x80000000                        // 0x1
    [LogField(16)] public int AbsorbSpellId { get; set; }            // 47753                            
    [LogField(17)] public string AbsorbSpellName { get; set; } = ""; // "Divine Aegis"                   
    [LogField(18)] public int AbsorbSpellSchool { get; set; }        // 0x2
    [LogField(19)] public double Amount { get; set; }                // 2059                               // 72228
    [LogField(20)] public double AmountBeforeAbsorb { get; set; }    // 18578                              // 373909

    public string[] CleanFields(string[] fields)
    {
        // If there are 21 fields, no need for swaps
        if (fields.Length == 21)
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
            fields[13],
            fields[14],
            fields[15],
            fields[9],
            fields[10],
            fields[11],
            fields[12],
            "nil",
            "nil",
            "nil",
            fields[16],
            fields[17],
        ];
    }
}