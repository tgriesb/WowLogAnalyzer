using WowLogAnalyzer.Entities;

namespace WowLogAnalyzer.Repository;
public interface IUserRepository 
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
}