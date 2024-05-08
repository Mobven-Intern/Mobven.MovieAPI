﻿using Microsoft.AspNetCore.Identity;
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

    public async Task<User> UserCheckAsync(string email)
    {
        var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null)
        {
            return user;
        }
        else
            throw new UserNotFoundException(email);
    }

    public async Task<User> GetUserCommentAsync(int id)
    {
        var user = await _dbSet.Include(u => u.Comments).FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            return user;
        }
        else
            throw new UserNotFoundException(id.ToString());
    }

    public async Task<User> GetUserRateAsync(int id)
    {
        var user = await _dbSet.Include(u => u.Rates).ThenInclude(u => u.Movie).FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            return user;
        }
        else
            throw new UserNotFoundException(id.ToString());
    }

    public async Task<bool> UserExistenceCheckAsync(string email)
    {
        var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null)
        {
            return true;
        }
        else
            return false;
    }

    public async Task EditUserRoleToAdminAsync(int id)
    {
        var user = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (user != null) 
        {
            user.Role = "Admin";
            await UpdateAsync(user);
        }
        else
        {
            throw new UserNotFoundException(id.ToString());
        }
    }
}
