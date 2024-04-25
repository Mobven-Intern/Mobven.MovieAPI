using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class RateService : BaseService<Rate, RateContract>, IRateService
{
    public RateService(IGenericRepository<Rate> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
