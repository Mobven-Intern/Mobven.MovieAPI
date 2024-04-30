using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> UserCheckAsync(string email);
    Task<User> GetUserCommentAsync(int id);
    Task<User> GetUserRateAsync(int id);
    Task<User> UserLoginCheckAsync(string email, string password);
    Task UserRegistration(User user);
}
