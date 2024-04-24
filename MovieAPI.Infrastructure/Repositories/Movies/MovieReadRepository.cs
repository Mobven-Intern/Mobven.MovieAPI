using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Repositories.Movies
{
    public class MovieReadRepository : GenericRepository<Movie>, IMovieReadRepository
    {
        public MovieReadRepository(MovieAPIDbContext context) : base(context)
        {
        }
    }
}
