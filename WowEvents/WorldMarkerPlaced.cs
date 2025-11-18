using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class WorldMarkerPlaced : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.WORLD_MARKER_PLACED;

    [LogField(1)] public int MapId { get; set; }      // 1008
    [LogField(2)] public int MarkerId { get; set; }      // 1
    [LogField(3)] public double X { get; set; }      // 3923.96
    [LogField(4)] public double Y { get; set; }      // 1251.38
}