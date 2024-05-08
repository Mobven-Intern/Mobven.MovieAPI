using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Repositories;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task CreateMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task<Movie> GetMovieByIdAsync(int id);
    Task<Movie> GetMovieCommentsAsync(int id);
    Task<List<Movie>> GetMoviesAsync();

}
