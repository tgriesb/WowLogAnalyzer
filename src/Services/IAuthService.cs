using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Models;

namespace WowLogAnalyzer.Services;

public interface IAuthService
{
    Task<LoginDto> LoginAsync(string email, string password, string? deviceName);
    Task<LoginDto?> RefreshAsync();
    Task LogoutAsync();
    int? GetCurrentUserId();
}