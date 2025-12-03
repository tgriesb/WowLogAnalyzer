using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class MapChange : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.MAP_CHANGE;

    [LogField(1)] public long MapId { get; set; }     // 456
    [LogField(2)] public string MapName { get; set; } = "";     // "Terrace of Endless Spring"
    [LogField(3)] public double X0 { get; set; }     // -789.583984
    [LogField(4)] public double X1 { get; set; }     // -1258.333984
    [LogField(5)] public double Y0 { get; set; }     // -2497.916016
    [LogField(6)] public double Y1 { get; set; }     // -3200.000000
}