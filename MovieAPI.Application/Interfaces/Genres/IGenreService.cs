using MovieAPI.Application.DTOs;

using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface IGenreService : IBaseService<Genre, GenreContract>
{
    Task<List<GenreContract>> GetGenresAsync();
}
