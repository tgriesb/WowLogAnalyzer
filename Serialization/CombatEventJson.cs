using System.Text.Json;
namespace WowLogAnalyzer.Serialization;

public static class CombatEventJson
{
    public static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };
}
