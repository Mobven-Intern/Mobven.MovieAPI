using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappers;

public class MovieMapperProfile : Profile
{
    public MovieMapperProfile()
    {
        CreateMap<Movie, MovieContract>();
        CreateMap<Movie, MovieContract>().ReverseMap();

        CreateMap<Movie, MovieCreateContract>();
        CreateMap<Movie, MovieCreateContract>().ReverseMap();

        CreateMap<Movie, MovieGetAllContract>();
        CreateMap<Movie, MovieGetAllContract>().ReverseMap();

        CreateMap<Movie, MovieGetCommentContract>();
        CreateMap<Movie, MovieGetCommentContract>().ReverseMap();

        CreateMap<Movie, MovieGetContract>();
        CreateMap<Movie, MovieGetContract>().ReverseMap();

        CreateMap<Movie, MovieUpdateContract>();
        CreateMap<Movie, MovieUpdateContract>().ReverseMap();
    }
}
