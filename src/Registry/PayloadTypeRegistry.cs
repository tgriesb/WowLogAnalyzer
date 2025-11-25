using WowLogAnalyzer.Enums;
using WowLogAnalyzer.WowEvents;
using System.Reflection;

namespace WowLogAnalyzer.Registry;
    
public static class PayloadTypeRegistry
{
    private static readonly Dictionary<CombatSubEventType, Type> _map;

    static PayloadTypeRegistry()
    {
        _map = new();

        var payloadTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t =>
                !t.IsAbstract &&
                typeof(ICombatEvent).IsAssignableFrom(t));

        foreach (var t in payloadTypes)
        {
            var temp = (ICombatEvent)Activator.CreateInstance(t)!;
            _map[temp.EventType] = t;
        }
    }

    public static Type? GetPayloadType(CombatSubEventType type) =>
        _map.TryGetValue(type, out var t) ? t : null;
}