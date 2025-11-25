using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.Entities;

public class CharacterEncounter
{
    [Key]
    public int Id { get; set; }

    public int SpecId { get; set; }

    [ForeignKey(nameof(SpecId))]
    public Spec Spec { get; set; } = null!;

    public int CharacterId { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; } = null!;

    public int EncounterId { get; set; }

    [ForeignKey(nameof(EncounterId))]
    public Encounter Encounter { get; set; } = null!;
}