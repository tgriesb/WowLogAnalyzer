using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class SpellBuildingHeal : ICombatEvent, ISourceDestCombatEvent, IHealCombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.SPELL_BUILDING_HEAL;

    [LogField(1)] public string SourceGUID { get; set; } = "";      
    [LogField(2)] public string SourceName { get; set; } = "";      
    [LogField(3)] public int SourceFlags { get; set; }        
    [LogField(4)] public int SourceRaidFlags { get; set; }        
    [LogField(5)] public string DestGUID { get; set; } = "";        
    [LogField(6)] public string DestName { get; set; } = "";        
    [LogField(7)] public int DestFlags { get; set; }        
    [LogField(8)] public int DestRaidFlags { get; set; }       
    [LogField(9)] public int SpellId { get; set; }      
    [LogField(10)] public string SpellName { get; set; } = "";      
    [LogField(11)] public int SpellSchool { get; set; }         
    [LogField(12)] public double Amount { get; set; }     
}