using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public interface ISourceDestCombatEvent
{
    public string SourceGUID { get; set; }
    public string SourceName { get; set; }
    public int SourceFlags { get; set; }
    public int SourceRaidFlags { get; set; }
    public string DestGUID { get; set; }
    public string DestName { get; set; }
    public int DestFlags { get; set; }
    public int DestRaidFlags { get; set; }
}