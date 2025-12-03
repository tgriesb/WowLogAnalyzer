using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public interface ISourceDestCombatEvent
{
    public string SourceGUID { get; set; }
    public string SourceName { get; set; }
    public long SourceFlags { get; set; }
    public long SourceRaidFlags { get; set; }
    public string DestGUID { get; set; }
    public string DestName { get; set; }
    public long DestFlags { get; set; }
    public long DestRaidFlags { get; set; }
}