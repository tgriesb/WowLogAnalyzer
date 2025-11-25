using WowLogAnalyzer.WowEvents;
using WowLogAnalyzer.Registry;
using WowLogAnalyzer.Enums;
using System.Text.Json;
namespace WowLogAnalyzer.Serialization;

public static class EventPayloadSerializer
{
    public static ICombatEvent Deserialize(
        CombatSubEventType type,
        object eventData)
    {
        var payloadType = PayloadTypeRegistry.GetPayloadType(type)
            ?? throw new Exception($"Unknown payload type: {type}");

        // Re-serialize dictionary and deserialize into the real payload type
        var json = JsonSerializer.Serialize(eventData, CombatEventJson.Options);

        return (ICombatEvent)JsonSerializer.Deserialize(
            json,
            payloadType,
            CombatEventJson.Options
        )!;
    }
}