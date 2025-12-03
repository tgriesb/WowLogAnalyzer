using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellLeech : ICombatEvent, ISourceDestCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_LEECH;

    [LogField(1)] public string SourceGUID { get; set; } = "";     
    [LogField(2)] public string SourceName { get; set; } = "";     
    [LogField(3)] public long SourceFlags { get; set; }       
    [LogField(4)] public long SourceRaidFlags { get; set; }       
    [LogField(5)] public string DestGUID { get; set; } = "";       
    [LogField(6)] public string DestName { get; set; } = "";       
    [LogField(7)] public long DestFlags { get; set; }       
    [LogField(8)] public long DestRaidFlags { get; set; }      
    [LogField(9)] public long SpellId { get; set; }     
    [LogField(10)] public string SpellName { get; set; } = "";     
    [LogField(11)] public long SpellSchool { get; set; }        
    [LogField(12)] public double Amount { get; set; }   
    [LogField(13)] public string PowerType { get; set; } = "";      
    [LogField(14)] public double ExtraAmount { get; set; }     
}