using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace WowLogAnalyzer.Response;

public class UserResponse
{

    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateTime LastLogin { get; set; } = DateTime.UtcNow;
}