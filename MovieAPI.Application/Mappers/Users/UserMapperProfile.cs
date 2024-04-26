using AutoMapper;
using MovieAPI.Application.DTOs;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Mappers;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<User, UserContract>();
        CreateMap<User, UserContract>().ReverseMap();

        CreateMap<User, UserGetCommentContract>();
        CreateMap<User, UserGetCommentContract>().ReverseMap();

        CreateMap<User, UserGetContract>();
        CreateMap<User, UserGetContract>().ReverseMap();

        CreateMap<User, UserGetRateContract>();
        CreateMap<User, UserGetRateContract>().ReverseMap();

        CreateMap<User, UserLoginContract>();
        CreateMap<User, UserLoginContract>().ReverseMap();

        CreateMap<User, UserRegisterContract>();
        CreateMap<User, UserRegisterContract>().ReverseMap();

        CreateMap<User, UserUpdateContract>();
        CreateMap<User, UserUpdateContract>().ReverseMap();

    }
}
