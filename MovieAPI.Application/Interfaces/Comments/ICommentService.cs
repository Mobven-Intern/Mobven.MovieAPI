using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface ICommentService : IBaseService<Comment, CommentContract>
{
    Task<CommentGetContract> GetCommentByIdAsync(int id);
    Task<List<CommentGetContract>> GetCommentsAsync();
    Task CreateCommentAsync(CommentContract requestModel);
}
