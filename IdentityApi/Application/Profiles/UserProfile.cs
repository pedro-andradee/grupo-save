using AutoMapper;
using IdentityApi.Application.Dtos;
using IdentityApi.Domain;

namespace IdentityApi.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, UserDto>()
        .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento.ToString("dd/MM/yyyy")));
    }
}