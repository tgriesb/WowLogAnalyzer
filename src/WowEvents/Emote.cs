using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class Emote : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.EMOTE;

    [LogField(1)] public string SourceGUID { get; set; } = "";  // Player-4385-05E60F02
    [LogField(2)] public string SourceName { get; set; } = "";  // "Holygran-Immerseus-US"
    [LogField(3)] public string DestGUID { get; set; } = "";    // Player-4385-05E528FE
    [LogField(4)] public string DestName { get; set; } = "";    // "Ugali-Immerseus-US"
    [LogField(5)] public string Message { get; set; } = "";    

}