namespace WowLogAnalyzer.Entities;

public class UserSession
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public string DeviceName { get; set; } = "Unknown"; // e.g. "Chrome on Windows"
    public string UserAgent { get; set; } = string.Empty;
    public string? IpAddress { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastSeenAt { get; set; }
    public DateTime? RevokedAt { get; set; }
    public string? RevokedReason { get; set; }

    public List<RefreshToken> RefreshTokens { get; set; } = new();

    public bool IsActive => RevokedAt == null;
}