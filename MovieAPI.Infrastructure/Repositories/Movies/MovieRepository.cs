using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;

namespace MovieAPI.Infrastructure.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly DbSet<Movie> _dbSet;
    public MovieRepository(MovieAPIDbContext context) : base(context)
    {
        _dbSet = context.Set<Movie>();
    }

    public async Task CreateMovieAsync(Movie movie)
    {
        throw new NotImplementedException();
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var entity = await _dbSet.Include(x => x.Genres)
                                 .Include(x => x.Tags)
                                 .Include(x => x.Comments)
                                 .Include(x => x.Rates)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        if(entity != null)
        {
            return entity;
        }
        else
            throw new Exception("Movie not found");
    }

    public async Task<Movie> GetMovieCommentsAsync(int id)
    {
        var entity = await _dbSet.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        if(entity != null)
        {
            return entity;
        }
        else
            throw new Exception("Movie not found");
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        var entity = await _dbSet.Include(x => x.Genres)
                                 .Include(x => x.Tags)
                                 .Include(x => x.Rates)
                                 .ToListAsync();
        if (entity != null)
        {
            return entity;
        }
        else
            throw new Exception("Movies not found");
    }

    

    public async Task UpdateMovieAsync(Movie movie)
    {
        throw new NotImplementedException();
    }
}
