using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WowLogAnalyzer.Entities;

public class Log
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = "";

    [Required]
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public string FileName { get; set; } = string.Empty;

    public int? GuildId { get; set; }

    [ForeignKey(nameof(GuildId))]
    public Guild Guild { get; set; } = null!;

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    public ICollection<CombatEvent> CombatEvents { get; set; } = [];

}