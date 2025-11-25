using System.ComponentModel.DataAnnotations;

namespace WowLogAnalyzer.Entities;

public class Guild
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Server { get; set; }

    public ICollection<Log> Logs { get; set; } = new List<Log>();
}