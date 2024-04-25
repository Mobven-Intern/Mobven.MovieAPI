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

    public async Task<bool> UserCheck(string email)
    {
        var user =  await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            return true;
        }
        return false;
    }
}
