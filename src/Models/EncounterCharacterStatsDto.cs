public class EncounterCharacterStatsDto
{
    public int CharacterId { get; set; }
    public string Character { get; set; } = "";
    public string Spec { get; set; } = "";
    public string Class { get; set; } = "";
    public double TotalDamage { get; set; }
    public double TotalAbsorb { get; set; }
    public double TotalHealing { get; set; }
    public int Deaths { get; set; }
    public double TotalDamageTaken { get; set; }

}
