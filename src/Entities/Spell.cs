using System.ComponentModel.DataAnnotations;

namespace WowLogAnalyzer.Entities;

public class Spell
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set;  } = "";


}