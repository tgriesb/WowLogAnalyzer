using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public interface IAbsorbCombatEvent
{
    public double Amount { get; set; }
}