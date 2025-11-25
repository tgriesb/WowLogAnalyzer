using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WowLogAnalyzer.Entities;

namespace WowLogAnalyzer.Services;
public interface IJwtSecurityService
{
    public string GenerateJwtToken(User user);
    public string GetExpiry();
}