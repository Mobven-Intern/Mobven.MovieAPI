using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Repositories.Users
{
    public class UserReadRepository : GenericRepository<User>, IUserReadRepository
    {
        public UserReadRepository(MovieAPIDbContext context) : base(context)
        {
        }
    }
}
