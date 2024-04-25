using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;

namespace MovieAPI.Infrastructure.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieAPIDbContext context) : base(context)
    {
    }
}
