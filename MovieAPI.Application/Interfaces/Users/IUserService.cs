using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface IUserService : IBaseService<User, UserContract>
{
    Task RegisterUserAsync(UserRegisterContract requestModel);
    Task<string> LoginUserAsync(UserLoginContract requestModel);
    Task<UserContract> GetUserByIdAsync(int id);
    Task<UserGetCommentContract> GetUserCommentAsync(int id);
    Task<UserGetRateContract> GetUserRateAsync(int id);
    Task<List<UserGetContract>> GetUsersAsync(); 
    Task EditUserRoleToAdminAsync(int id);
}
