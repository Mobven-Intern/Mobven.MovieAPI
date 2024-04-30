using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> UserCheckAsync(string email);
    Task<User> GetUserCommentAsync(int id);
    Task<User> GetUserRateAsync(int id);
    Task<bool> UserExistenceCheckAsync(string email);
}
