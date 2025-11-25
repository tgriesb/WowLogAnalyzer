using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Response;

namespace WowLogAnalyzer.Extensions;

public static class UserExtensions
{
    public static UserResponse ToResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            LastLogin = user.LastLogin
        };
    }

    public static IEnumerable<UserResponse> ToResponseList(this IEnumerable<User> users)
    {
        if (users == null)
        {
            return Enumerable.Empty<UserResponse>();
        }

        return users.Select(u => u.ToResponse());
    }
}