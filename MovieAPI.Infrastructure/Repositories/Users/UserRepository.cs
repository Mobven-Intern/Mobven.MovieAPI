using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;

namespace MovieAPI.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DbSet<User> _dbSet;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(MovieAPIDbContext context, IPasswordHasher<User> passwordHasher) : base(context)
    {
        _dbSet = context.Set<User>();
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> UserCheckAsync(string email)
    {
        var user =  await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null)
        {
            return true;
        }
        return false;
    }

    public async Task<User> GetUserCommentAsync(int id)
    {
        var user = await _dbSet.Include(u => u.Comments).FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            return user;
        }
        else
            throw new Exception("User not found");
    }

    public async Task<User> GetUserRateAsync(int id)
    {
        var user = await _dbSet.Include(u => u.Rates).ThenInclude(u => u.Movie).FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            return user;
        }
        else
            throw new Exception("User not found");
    }

    public async Task<User> UserLoginCheckAsync(string email, string password)
    {
        var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Success)
            {
                return user;
            }
            else
                throw new Exception($"Failed to login {user.Email}");
        }
        else
            throw new Exception("User not found");
    }

    public async Task UserRegistration(User user)
    {
        var existCheck = await UserCheckAsync(user.Email);
        if (!existCheck)
        {
            string hashedPassword = _passwordHasher.HashPassword(user, user.Password);
            user.Password = hashedPassword;
            await AddAsync(user);
        }
        else
            throw new Exception("User already exist");
    }
}
