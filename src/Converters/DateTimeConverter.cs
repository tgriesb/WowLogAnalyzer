using System.Text.Json;
using System.Text.Json.Serialization;

namespace WowLogAnalyzer.Converters;
public class DateTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "MM/dd/yyyy hh:mm tt";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.Parse(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // TODO: Let users choose a Timezone
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        // Convert the UTC time to CST
        DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(value, cstZone);

        writer.WriteStringValue(cstTime.ToString(Format).ToLower());
    }
}