using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class TagService : BaseService<Tag, TagContract>, ITagService
{
    public TagService(IGenericRepository<Tag> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
