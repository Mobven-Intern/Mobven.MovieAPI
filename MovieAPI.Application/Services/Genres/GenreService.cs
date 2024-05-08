using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Repositories;

namespace MovieAPI.Application.Services;

public class GenreService : BaseService<Genre, GenreContract>, IGenreService
{
    private readonly IGenericRepository<Genre> _genreRepository;
    private readonly IMapper _mapper;
    public GenreService(IGenericRepository<Genre> repository, IMapper mapper) : base(repository, mapper)
    {
        _genreRepository = repository;
        _mapper = mapper;
    }
    public async Task CreateGenreAsync(GenreContract requestModel)
    {
        var model = _mapper.Map<Genre>(requestModel);
        await _genreRepository.AddAsync(model);
    }

    public async Task<GenreContract> GetGenreByIdAsync(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        return _mapper.Map<GenreContract>(genre);
    }

    public async Task<List<GenreContract>> GetCommentsAsync()
    {
        var genres = await _genreRepository.GetAllAsync();
        return _mapper.Map<List<GenreContract>>(genres);
    }
}