using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class CommentService : BaseService<Comment, CommentContract>, ICommentService
{
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly IMapper  _mapper;
    public CommentService(IGenericRepository<Comment> repository, IMapper mapper) : base(repository, mapper)
    {
        _commentRepository = repository;
        _mapper = mapper;
    }

    public async Task CreateCommentAsync(CommentContract requestModel)
    {
        var model = _mapper.Map<Comment>(requestModel);
        await _commentRepository.AddAsync(model);
    }

    public async Task<CommentGetContract> GetCommentByIdAsync(int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        return _mapper.Map<CommentGetContract>(comment);
    }

    public async Task<List<CommentGetContract>> GetCommentsAsync()
    {
        var comments = await _commentRepository.GetAllAsync();
        return _mapper.Map<List<CommentGetContract>>(comments);
    }
 
}
