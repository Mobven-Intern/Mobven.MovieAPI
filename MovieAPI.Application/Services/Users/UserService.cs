using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Repositories;

namespace MovieAPI.Application.Services;

public class UserService : BaseService<User, UserContract>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly ICacheService _cacheService;

    public UserService(IGenericRepository<User> repository, IMapper mapper, IUserRepository userRepository, IAuthService authService, IPasswordHasher<User> passwordHasher, ICacheService cacheService) : base(repository, mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authService = authService;
        _passwordHasher = passwordHasher;
        _cacheService = cacheService;
    }

    public async Task<UserContract> GetUserByIdAsync(int id)
    {
        string cacheKey = "User-Id: " + id;
        return await _cacheService.GetOrAddAsync(cacheKey, async () =>
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserContract>(user);
            
        }, options: new()
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        });
    }

    public async Task<UserGetCommentContract> GetUserCommentAsync(int id)
    {
        var user = await _userRepository.GetUserCommentAsync(id);
        return _mapper.Map<UserGetCommentContract>(user);
    }

    public async Task<UserGetRateContract> GetUserRateAsync(int id)
    {
        var user = await _userRepository.GetUserRateAsync(id);
        return _mapper.Map<UserGetRateContract>(user);
    }

    public async Task<List<UserGetContract>> GetUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserGetContract>>(users);
    }

    public async Task<string> LoginUserAsync(UserLoginContract requestModel)
    {
        var user = await _userRepository.UserCheckAsync(requestModel.Email);
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, requestModel.Password);
        if (result == PasswordVerificationResult.Success)
        {
            //return _authService.Token(user);
            string cacheKey = "UserLogin-Id: " + user.Id;
            return await _cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                return _authService.Token(user);

            }, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            });
        }
        else
            throw new UserPasswordIncorrectException(user.Email);
    }

    public async Task<bool> UpdateUserAsync(UserContract requestModel)
    {
        var model = _mapper.Map<User>(requestModel);
        return await _userRepository.UpdateAsync(model);
    }

    public async Task RegisterUserAsync(UserRegisterContract requestModel)
    {
        var userCheck = await _userRepository.UserExistenceCheckAsync(requestModel.Email);
        if (!userCheck)
        {
            var entity = _mapper.Map<User>(requestModel);
            entity.Password = _passwordHasher.HashPassword(entity, requestModel.Password);
            await _userRepository.AddAsync(entity);
        }
        else
        {
            throw new UserAlreadyExistsException(requestModel.Email);

        }

    }

    public async Task EditUserRoleToAdminAsync(int id)
    {
        await _userRepository.EditUserRoleToAdminAsync(id);
    }
}
