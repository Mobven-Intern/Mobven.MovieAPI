using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class GenreService : BaseService<Genre, GenreContract>, IGenreService
{
    public GenreService(IGenericRepository<Genre> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}