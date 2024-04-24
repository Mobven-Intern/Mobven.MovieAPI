using MovieAPI.Domain;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Repositories.Comments
{
    public class CommentReadRepository : GenericRepository<Comment>, ICommentReadRepository
    {
        public CommentReadRepository(MovieAPIDbContext context) : base(context)
        {
        }
    }
}
