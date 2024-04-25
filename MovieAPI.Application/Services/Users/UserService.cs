using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class UserService : BaseService<User, UserContract>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IGenericRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(repository, mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task CreateUser(UserContract user)
    {
        var userCheck = await _userRepository.UserCheck(user.Email);
        if (userCheck)
        {
            var entity = _mapper.Map<User>(user);
            await _userRepository.AddAsync(entity);
        }
        else
            throw new Exception("User already exist");
    }
}
