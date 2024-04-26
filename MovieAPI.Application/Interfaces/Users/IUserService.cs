using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface IUserService : IBaseService<User, UserContract>
{
    Task CreateUserAsync(UserContract requestModel);
    Task RegisterUserAsync(UserRegisterContract requestModel);
    Task<bool> LoginUserAsync(UserLoginContract requestModel);
    Task<UserGetContract> GetUserByIdAsync(int id);
    Task<UserGetCommentContract> GetUserCommentAsync(int id);
    Task<UserGetRateContract> GetUserRateAsync(int id);
    Task<List<UserGetContract>> GetUsersAsync();
    Task<bool> UpdateUserAsync(UserContract requestModel);
}
