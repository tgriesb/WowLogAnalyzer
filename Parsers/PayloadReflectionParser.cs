using System.Globalization;
using System.Reflection;
using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.WowEvents;

namespace WowLogAnalyzer.Parsers;
public static class PayloadReflectionParser
{
    public static ICombatEvent Parse(string[] fields, Type targetType)
    {
        var obj = (ICombatEvent)Activator.CreateInstance(targetType)!;

        // Mainly for ABS, because there can be different fields
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

    // Convert raw string to target type
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