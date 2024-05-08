using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class RateService : BaseService<Rate, RateContract>, IRateService
{
    private readonly IGenericRepository<Rate> _rateRepository;
    private readonly IMapper _mapper;
    public RateService(IGenericRepository<Rate> repository, IMapper mapper) : base(repository, mapper)
    {
        _rateRepository = repository;
        _mapper = mapper;
    }
    public async Task CreateRateAsync(RateContract requestModel)
    {
        var model = _mapper.Map<Rate>(requestModel);
        await _rateRepository.AddAsync(model);
    }

    public async Task<RateGetContract> GetRateByIdAsync(int id)
    {
        var rate = await _rateRepository.GetByIdAsync(id);
        return _mapper.Map<RateGetContract>(rate);
    }

    public async Task<List<RateGetContract>> GetRatesAsync()
    {
        var rates = await _rateRepository.GetAllAsync();
        return _mapper.Map<List<RateGetContract>>(rates);
    }
}
