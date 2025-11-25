using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public interface IHealCombatEvent
{
    public double Amount { get; set; }
}