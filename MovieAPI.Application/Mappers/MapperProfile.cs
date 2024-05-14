using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserContract>();
        CreateMap<User, UserContract>().ReverseMap();

        CreateMap<PagedResponse<User>,PagedResponse<UserContract>>();
        CreateMap<PagedResponse<User>, PagedResponse<UserContract>>().ReverseMap();

        CreateMap<Movie, MovieContract>();
        CreateMap<Movie, MovieContract>().ReverseMap();

        CreateMap<PagedResponse<Movie>, PagedResponse<MovieContract>>();
        CreateMap<PagedResponse<Movie>, PagedResponse<MovieContract>>().ReverseMap();

        CreateMap<Genre, GenreContract>();
        CreateMap<Genre, GenreContract>().ReverseMap();

        CreateMap<Tag, TagContract>();
        CreateMap<Tag, TagContract>().ReverseMap();

        CreateMap<Comment, CommentContract>();
        CreateMap<Comment, CommentContract>().ReverseMap();

        CreateMap<Rate, RateContract>();
        CreateMap<Rate, RateContract>().ReverseMap();
    }
}
