using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class TagService : BaseService<Tag, TagContract>, ITagService
{
    private readonly IGenericRepository<Tag> _tagRepository;
    private readonly IMapper _mapper;
    public TagService(IGenericRepository<Tag> repository, IMapper mapper) : base(repository, mapper)
    {
        _tagRepository = repository;
        _mapper = mapper;
    }
    public async Task CreateTagAsync(TagContract requestModel)
    {
        var model = _mapper.Map<Tag>(requestModel);
        await _tagRepository.AddAsync(model);
    }

    public async Task<TagContract> GetTagByIdAsync(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        return _mapper.Map<TagContract>(tag);
    }

    public async Task<List<TagContract>> GetTagsAsync()
    {
        var tags = await _tagRepository.GetAllAsync();
        return _mapper.Map<List<TagContract>>(tags);
    }
}
