using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> UserCheckAsync(string email);
    Task<User> GetUserCommentAsync(int id);
    Task<User> GetUserRateAsync(int id);
    Task<bool> UserLoginCheckAsync(string username, string password);
    Task UserUpdateAsync(User user);
    Task<User> UserGetByEmailAsync(string email);
}
