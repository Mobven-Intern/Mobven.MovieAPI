using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class GenreService : BaseService<Genre, GenreContract>, IGenreService
{
    private readonly IGenericRepository<Genre> _genreRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GenreService(IGenericRepository<Genre> repository, IMapper mapper, ICacheService cacheService) : base(repository, mapper)
    {
        _genreRepository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
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

    public async Task<List<GenreContract>> GetGenresAsync()
    {
        const string cacheKey = "Genres";

        return await _cacheService.GetOrAddAsync(cacheKey, async () =>
        {
            var genres = await _genreRepository.GetAllAsync();
            var model = _mapper.Map<List<GenreContract>>(genres);
            return model;
        }, options: new()
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        });
    }
}