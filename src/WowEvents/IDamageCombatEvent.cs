using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public interface IDamageCombatEvent
{
    public double Amount { get; set; }
}