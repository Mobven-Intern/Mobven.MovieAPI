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

    public async Task CreateUser(UserContract requestModel)
    {
        var userCheck = await _userRepository.UserCheck(requestModel.Username);
        if (!userCheck)
        {
            var entity = _mapper.Map<User>(requestModel);
            await _userRepository.AddAsync(entity);
        }
        else
            throw new Exception("User already exist");
    }

    public async Task<UserGetContract> GetUserById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user != null)
        {
            return _mapper.Map<UserGetContract>(user);
        }
        else
            throw new Exception("User not found.");
    }

    public async Task<UserGetCommentContract> GetUserComment(int id)
    {
        var user = await _userRepository.GetUserComment(id);
        if(user != null)
        {
            return _mapper.Map<UserGetCommentContract>(user);
        }
        else
            throw new Exception("User not found.");
    }

    public async Task<UserGetRateContract> GetUserRate(int id)
    {
        var user = await _userRepository.GetUserRate(id);
        if (user != null)
        {
            return _mapper.Map<UserGetRateContract>(user);
        }
        else
            throw new Exception("User not found.");
    }

    public async Task<List<UserGetContract>> GetUsers()
    {
        var users = await _userRepository.GetAllAsync();
        if(users != null)
        {
            return _mapper.Map<List<UserGetContract>>(users);
        }
        else
            throw new Exception("Users not found.");
    }

    public async Task<bool> LoginUser(UserLoginContract requestModel)
    {
        var loginCheck = await _userRepository.UserLoginCheck(requestModel.Username, requestModel.Password);
        if (loginCheck)
        {
            return true;
        }
        else
            throw new Exception("Users not found.");
    }

    public async Task<bool> UpdateUser(UserContract requestModel)
    {
        var model = _mapper.Map<User>(requestModel);
        if (model != null) 
        {
            return await _userRepository.UpdateAsync(model);
        }
        else
            throw new Exception("Users not found.");
    }

    public async Task RegisterUser(UserRegisterContract requestModel)
    {
        var userCheck = await _userRepository.UserCheck(requestModel.Username);
        if (!userCheck)
        {
            var entity = _mapper.Map<User>(requestModel);
            await _userRepository.AddAsync(entity);
        }
        else
            throw new Exception("User already exist");
    }
}
