using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WowLogAnalyzer.Entities;

public class SpecUniqueSpell
{
    [Key]
    public int Id { get; set; }

    public int? SpecId { get; set; }

    [ForeignKey(nameof(SpecId))]
    public Spec Spec { get; set; } = null!;

    public int SpellId { get; set; }

}