namespace WowLogAnalyzer.Models;

public class LoginDto
{
    public int Id { get; set; }
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string Username { get; set; } = "";
    public string DeviceName { get; set; } = "Browser";
}