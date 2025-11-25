using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class EnvironmentalHeal : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.ENVIRONMENTAL_HEAL;

    // DOes this event exist?
}