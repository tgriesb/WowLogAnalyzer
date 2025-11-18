using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class EncounterStart : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.ENCOUNTER_START;

    [LogField(1)] public int EncounterId { get; set; } // "encounterId"
    [LogField(2)] public string EncounterName { get; set; } = ""; // "encounterName"
    [LogField(3)] public int DifficultyId { get; set; } // "difficultyId"
    [LogField(4)] public int GroupSize { get; set; } // "groupSize"
    
}