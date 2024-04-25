using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces;

public interface ICommentService : IBaseService<Comment, CommentContract>
{
}
