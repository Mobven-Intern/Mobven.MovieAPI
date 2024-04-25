using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;

namespace MovieAPI.Infrastructure.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(MovieAPIDbContext context) : base(context)
    {
    }
}
