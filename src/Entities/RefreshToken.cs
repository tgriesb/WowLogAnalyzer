namespace WowLogAnalyzer.Entities;

public class RefreshToken
{
    public int Id { get; set; }

    public int UserSessionId { get; set; }
    public UserSession UserSession { get; set; } = null!;

    public string TokenHash { get; set; } = null!; // SHA256 of token
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedByIp { get; set; } = string.Empty;

    public DateTime? RevokedAt { get; set; }
    public string? RevokedByIp { get; set; }
    public string? RevokedReason { get; set; }

    public int? ReplacedByTokenId { get; set; }
    public RefreshToken? ReplacedByToken { get; set; }

    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    public bool IsRevoked => RevokedAt != null;
    public bool IsActive => !IsRevoked && !IsExpired && UserSession.IsActive;
}