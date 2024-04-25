using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class MovieService : BaseService<Movie, MovieContract>, IMovieService
{
    public MovieService(IGenericRepository<Movie> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
