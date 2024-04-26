using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;

namespace MovieAPI.Infrastructure.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly DbSet<User> _dbSet;
    public CommentRepository(MovieAPIDbContext context) : base(context)
    {
        _dbSet = context.Set<User>();
    }
}
