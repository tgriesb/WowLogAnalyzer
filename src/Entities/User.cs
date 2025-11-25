using System.ComponentModel.DataAnnotations;
namespace WowLogAnalyzer.Entities;

public class User 
{
    public User()
    {

    }

    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = string.Empty;
    public DateTime LastLogin { get; set; } = DateTime.UtcNow;
    public ICollection<Log> Logs { get; set; } = [];

    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
    }
}
