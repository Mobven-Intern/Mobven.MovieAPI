using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface IUserService : IBaseService<User, UserContract>
{
    Task CreateUser(UserContract user);
}
