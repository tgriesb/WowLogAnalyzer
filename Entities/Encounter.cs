using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WowLogAnalyzer.Entities;

[Table("encounters")]
public class Encounter
{
    [Key]
    public int Id { get; set; }
    public string EncounterName { get; set; } = string.Empty;
    public int EncounterId { get; set; }

    public int? StartCombatEventId { get; set; }
    [ForeignKey(nameof(StartCombatEventId))]
    public CombatEvent StartCombatEvent { get; set; } = null!;

    public int? EndCombatEventId { get; set; }
    [ForeignKey(nameof(EndCombatEventId))]
    public CombatEvent EndCombatEvent { get; set; } = null!;

    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public Difficulty Difficulty { get; set; }
    public bool Success { get; set; }
    public required Log Log { get; set; }
    public int? LogId { get; set; }



    [InverseProperty("Encounter")]
    public ICollection<CombatEvent> CombatEvents { get; set; } = [];
}