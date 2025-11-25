using System.ComponentModel.DataAnnotations;

namespace WowLogAnalyzer.Entities;

public class Character
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = "";

    public string Server { get; set; } = "";

    public string Guid  { get; set; } = "";


}