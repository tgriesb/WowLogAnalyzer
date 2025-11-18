using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class ZoneChange : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.ZONE_CHANGE;

    [LogField(1)] public int InstanceId { get; set; }
    [LogField(2)] public string ZoneName { get; set; } = "";
    [LogField(3)] public int DifficultyId { get; set; }

}