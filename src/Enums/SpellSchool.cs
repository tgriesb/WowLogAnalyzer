using WowLogAnalyzer.Enums;

[Flags]
public enum SpellSchool
{
    None        = 0,
    Physical    = 1 << 0, // 1
    Holy        = 1 << 1, // 2
    Fire        = 1 << 2, // 4
    Nature      = 1 << 3, // 8
    Frost       = 1 << 4, // 16
    Shadow      = 1 << 5, // 32
    Arcane      = 1 << 6, // 64

    // Hybrid Schools
    Frostfire   = Frost | Fire,         // 20
    Shadowflame = Shadow | Fire,        // 36
    Holyshadow  = Holy | Shadow,        // 34
    Elemental   = Fire | Frost | Nature // 28
}