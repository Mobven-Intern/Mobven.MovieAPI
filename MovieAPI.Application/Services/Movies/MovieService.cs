using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class MovieService : BaseService<Movie, MovieContract>, IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    public MovieService(IGenericRepository<Movie> repository, IMapper mapper, IMovieRepository movieRepository) : base(repository, mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task CreateMovieAsync(MovieCreateContract requestModel)
    {
        var model = _mapper.Map<Movie>(requestModel);
        model.CreatedBy = "doa";
        await _movieRepository.AddAsync(model);
    }

    public async Task<MovieGetContract> GetMovieByIdAsync(int id)
    {
        var model = await _movieRepository.GetMovieByIdAsync(id);
        return _mapper.Map<MovieGetContract>(model);
    }

    public async Task<MovieGetCommentContract> GetMovieCommentsAsync(int id)
    {
        var model = await _movieRepository.GetMovieCommentsAsync(id);
        return _mapper.Map<MovieGetCommentContract>(model);
    }

    public async Task<List<MovieGetAllContract>> GetMoviesAsync()
    {
        var model = await _movieRepository.GetMoviesAsync();
        return _mapper.Map<List<MovieGetAllContract>>(model);
    }

    public async Task UpdateMovieAsync(MovieUpdateContract requestModel)
    {
        var model = _mapper.Map<Movie>(requestModel);
        model.CreatedBy = "doa";
        await _movieRepository.UpdateAsync(model);
    }
}
