using System.ComponentModel.DataAnnotations;

namespace WowLogAnalyzer.Entities;

public class Spec
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set;  } = "";
    public string Class { get; set;  } = "";
}