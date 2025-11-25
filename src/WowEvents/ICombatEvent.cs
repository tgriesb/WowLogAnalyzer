using SQLitePCL;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public interface ICombatEvent
{
    CombatSubEventType EventType { get; }

    public string[] CleanFields(string[] fields)
    {
        return fields;
    }
}