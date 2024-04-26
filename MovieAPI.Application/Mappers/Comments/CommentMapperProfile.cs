using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappers;

public class CommentMapperProfile : Profile
{
    public CommentMapperProfile()
    {
        CreateMap<Comment, CommentContract>();
        CreateMap<Comment, CommentContract>().ReverseMap();

        CreateMap<Comment, CommentGetContract>();
        CreateMap<Comment, CommentGetContract>().ReverseMap();
    }
}
