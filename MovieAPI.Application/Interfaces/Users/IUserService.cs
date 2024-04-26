using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface IUserService : IBaseService<User, UserContract>
{
    Task CreateUser(UserContract requestModel);
    Task RegisterUser(UserRegisterContract requestModel);
    Task<bool> LoginUser(UserLoginContract requestModel);
    Task<UserGetContract> GetUserById(int id);
    Task<UserGetCommentContract> GetUserComment(int id);
    Task<UserGetRateContract> GetUserRate(int id);
    Task<List<UserGetContract>> GetUsers();
    Task<bool> UpdateUser(UserContract requestModel);
}
