using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;

namespace MovieAPI.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DbSet<User> _dbSet;
    public UserRepository(MovieAPIDbContext context) : base(context)
    {
        _dbSet = context.Set<User>();
    }

    public async Task<bool> UserCheckAsync(string username)
    {
        var user =  await _dbSet.FirstOrDefaultAsync(x => x.Username == username);
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

    public async Task<bool> UserLoginCheckAsync(string email, string password)
    {
        var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null && user.Password == password)
        {
            return true;
        }
        else
            throw new Exception("User not found");
    }

    public Task UserUpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> UserGetByEmailAsync(string email)
    {
        var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null)
        {
            return user;
        }
        else
            throw new Exception("User not found");
    }
}
