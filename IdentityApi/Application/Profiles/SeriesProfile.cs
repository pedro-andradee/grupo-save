using Application.Dtos;
using AutoMapper;
using IdentityApi.Application.Dtos;
using IdentityApi.Domain;

namespace Application.Profiles;

public class SeriesProfile : Profile
{
    public SeriesProfile()
    {
        CreateMap<Series, SeriesDto>();
        CreateMap<CreateSeriesDto, Series>();
        CreateMap<UpdateSeriesDto, Series>();
    }
}