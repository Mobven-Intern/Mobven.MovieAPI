using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;

namespace MovieAPI.Application.Services;

public class CommentService : BaseService<Comment, CommentContract>, ICommentService
{
    public CommentService(IGenericRepository<Comment> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
