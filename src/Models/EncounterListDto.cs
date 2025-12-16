public class EncounterListDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public bool Success { get; set; }
    public string Duration { get; set; } = String.Empty;
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }
    public string Instance { get; set; } = String.Empty;
}