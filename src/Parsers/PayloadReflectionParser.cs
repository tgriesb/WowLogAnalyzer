using System.Globalization;
using System.Reflection;
using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.WowEvents;

namespace WowLogAnalyzer.Parsers;
/// <summary>
/// Uses reflection to map raw CSV string arrays from WoW combat logs to strongly-typed event objects.
/// </summary>
/// <remarks>
/// <para>
/// This parser is the core of the log parsing pipeline. It works by:
/// <list type="number">
/// <item><description>Taking a string array (CSV fields from a log line)</description></item>
/// <item><description>Instantiating a target event class (e.g., SpellDamage, EnchantApplied)</description></item>
/// <item><description>Reading <see cref="LogFieldAttribute"/> on each property to determine which array index to map</description></item>
/// <item><description>Converting the string value to the correct type (int, bool, double, etc.)</description></item>
/// <item><description>Setting the property on the instance</description></item>
/// </list>
/// </para>
/// <para>
/// The <see cref="LogFieldAttribute.Index"/> determines the column position in the CSV.
/// </para>
/// </remarks>
public static class PayloadReflectionParser
{
    /// <summary>
    /// Instantiates and populates a specific combat event type from raw log field strings.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method uses reflection to:
    /// <list type="bullet">
    /// <item><description>Create an instance of the target type via <see cref="Activator.CreateInstance"/></description></item>
    /// <item><description>Clean the fields array (some event types like ABS require field manipulation)</description></item>
    /// <item><description>Iterate through all properties decorated with <see cref="LogFieldAttribute"/></description></item>
    /// <item><description>Map CSV array indices to properties and convert types</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// If an index is out of bounds or a property lacks the attribute, it is skipped silently.
    /// </para>
    /// </remarks>
    /// <param name="fields">The raw string array split from a log line (CSV format).</param>
    /// <param name="targetType">The event class type to instantiate (must implement <see cref="ICombatEvent"/>).</param>
    /// <returns>A fully populated instance of the target event type.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if a field cannot be converted to its target property type.
    /// The exception message includes the event type, property name, and raw value.
    /// </exception>
    public static ICombatEvent Parse(string[] fields, Type targetType)
    {
        var obj = (ICombatEvent)Activator.CreateInstance(targetType)!;

        // Mainly for ABS, because there can be different fields in differnet positions, thank you Blizzard.
        fields = obj.CleanFields(fields);

        var type = targetType;

        foreach (var prop in type.GetProperties())
        {
            var attr = prop.GetCustomAttribute<LogFieldAttribute>();
            if (attr == null) continue;

            int i = attr.Index;
            if (i < 0 || i >= fields.Length) continue;
        
            try
            {
                object? value = ConvertField(fields[i], prop.PropertyType);
                prop.SetValue(obj, value);
            } catch(Exception ex)
            {
                throw new InvalidOperationException($"Unable to set {obj.GetType().Name}.{prop.Name} to: {fields[i]}\n{ex.ToString()}");
            }
        }

        return obj;
    }
    /// <summary>
    /// Converts a raw string value to its target type, handling WoW-specific formats.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method handles the following conversions:
    /// <list type="bullet">
    /// <item><description><strong>Null values:</strong> Empty strings and "nil" are converted to null</description></item>
    /// <item><description><strong>Hexadecimal:</strong> Values starting with "0x" are parsed as base-16 integers</description></item>
    /// <item><description><strong>Strings:</strong> Returned as-is after trimming quotes</description></item>
    /// <item><description><strong>Integers:</strong> Parsed as decimal or hex depending on format</description></item>
    /// <item><description><strong>Longs:</strong> Parsed as decimal or hex (used for large GUIDs)</description></item>
    /// <item><description><strong>Floating Point:</strong> Parsed using invariant culture (decimal separator is always '.')</description></item>
    /// <item><description><strong>Booleans:</strong> "1" or "true" (case-insensitive) = true; all others = false</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// Nullable types (e.g., <c>int?</c>, <c>double?</c>) are handled the same way as their non-nullable equivalents.
    /// </para>
    /// </remarks>
    /// <param name="raw">The raw string value from the log field.</param>
    /// <param name="target">The target type to convert to (e.g., int, bool, string).</param>
    /// <returns>The converted value, or null if the input is empty/nil.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the target type is not supported.</exception>
    private static object? ConvertField(string raw, Type target)
    {
        raw = raw.Trim().Trim('"');

        // Null
        if (string.IsNullOrEmpty(raw) || raw == "nil")
            return null;

        bool isHex = raw.StartsWith("0x", StringComparison.OrdinalIgnoreCase);

        // String
        if (target == typeof(string))
            return raw;

        // Ints
        if (target == typeof(int))
            return isHex ? Convert.ToInt32(raw, 16) : int.Parse(raw);

        if (target == typeof(int?))
            return isHex ? Convert.ToInt32(raw, 16) : int.Parse(raw);

        if (target == typeof(long))
            return isHex ? Convert.ToInt64(raw, 16) : long.Parse(raw);

        if (target == typeof(long?))
            return isHex ? Convert.ToInt64(raw, 16) : long.Parse(raw);

        // Floats/Doubles
        if (target == typeof(double))
            return isHex
                ? Convert.ToInt64(raw, 16)  // convert hex → integer → double
                : double.Parse(raw, CultureInfo.InvariantCulture);

        if (target == typeof(double?))
            return isHex
                ? Convert.ToInt64(raw, 16)
                : double.Parse(raw, CultureInfo.InvariantCulture);

        if (target == typeof(float))
            return isHex
                ? Convert.ToInt32(raw, 16)
                : float.Parse(raw, CultureInfo.InvariantCulture);

        if (target == typeof(float?))
            return isHex
                ? Convert.ToInt32(raw, 16)
                : float.Parse(raw, CultureInfo.InvariantCulture);

        // Bools
        if (target == typeof(bool))
            return raw == "1" || raw.Equals("true", StringComparison.OrdinalIgnoreCase);

        if (target == typeof(bool?))
            return raw == "1" || raw.Equals("true", StringComparison.OrdinalIgnoreCase);

        throw new InvalidOperationException($"Unsupported type: {target}");
    }
}