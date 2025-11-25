using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.Utilities;

public static class CombatEventMapper
{
    public static CombatSubEventType ParseSubEvent(string raw)
    {
        if (Enum.TryParse(raw, true, out CombatSubEventType result))
            return result;

        return CombatSubEventType.Unknown;
    }

    public static CombatEventCategory GetCategory(CombatSubEventType subEvent)
    {
        var name = subEvent.ToString();

        if (name.StartsWith("SWING")) return CombatEventCategory.Melee;
        if (name.StartsWith("RANGE")) return CombatEventCategory.Range;
        if (name.StartsWith("SPELL_PERIODIC")) return CombatEventCategory.Periodic;
        if (name.StartsWith("SPELL")) return CombatEventCategory.Spell;
        if (name.StartsWith("ENVIRONMENTAL")) return CombatEventCategory.Environmental;
        if (name.StartsWith("DAMAGE_SPLIT")) return CombatEventCategory.DamageSplit;
        if (name.StartsWith("UNIT")) return CombatEventCategory.Unit;
        if (name.StartsWith("PARTY")) return CombatEventCategory.Party;

        return CombatEventCategory.Unknown;
    }

    public static IEnumerable<int> SpellEvents()
    {
        return [
            (int) CombatSubEventType.RANGE_DAMAGE,
            (int) CombatSubEventType.RANGE_MISSED,
            (int) CombatSubEventType.SPELL_CAST_START,
            (int) CombatSubEventType.SPELL_CAST_SUCCESS,
            (int) CombatSubEventType.SPELL_CAST_FAILED,
            (int) CombatSubEventType.SPELL_DAMAGE,
            (int) CombatSubEventType.SPELL_MISSED,
            (int) CombatSubEventType.SPELL_HEAL
        ];
    }

    public static int[] DamageEvents()
    {
        return [
            (int) CombatSubEventType.SWING_DAMAGE,
            (int) CombatSubEventType.SWING_DAMAGE_LANDED,
            (int) CombatSubEventType.SPELL_DAMAGE
        ];
    }

    public static int[] HealEvents()
    {
        return [
            (int) CombatSubEventType.SPELL_HEAL
        ];
    }

     public static int[] AbsorbEvents()
    {
        return [
            (int) CombatSubEventType.SPELL_ABSORBED
        ];
    }
}