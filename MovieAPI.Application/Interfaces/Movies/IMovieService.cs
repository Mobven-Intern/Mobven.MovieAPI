using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface IMovieService : IBaseService<Movie, MovieContract>
{
    Task CreateMovieAsync(MovieCreateContract requestModel);
    Task UpdateMovieAsync(MovieUpdateContract requestModel);
    Task<MovieGetContract> GetMovieByIdAsync(int id);
    Task<MovieGetCommentContract> GetMovieCommentsAsync(int id);
    Task<List<MovieGetAllContract>> GetMoviesAsync();
}
