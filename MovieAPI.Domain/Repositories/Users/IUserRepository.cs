using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> UserCheck(string email);
    Task<User> GetUserComment(int id);
    Task<User> GetUserRate(int id);
    Task<bool> UserLoginCheck(string username, string password);
}
