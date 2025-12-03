using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class WorldMarkerRemoved : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.WORLD_MARKER_REMOVED;

    [LogField(1)] public long MarkerId { get; set; }      // 1
}