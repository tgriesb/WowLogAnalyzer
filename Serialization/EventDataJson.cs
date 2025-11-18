using System.Text.Json;

namespace WowLogAnalyzer.Serialization;

public static class EventDataJson
{
    public static string Serialize(object value)
        => JsonSerializer.Serialize(value, CombatEventJson.Options);

    public static Dictionary<string, object> Deserialize(string json)
        => JsonSerializer.Deserialize<Dictionary<string, object>>(json, CombatEventJson.Options)!;
}   