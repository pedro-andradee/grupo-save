using Application.Dtos;
using AutoMapper;
using IdentityApi.Application.Dtos;
using IdentityApi.Domain;

namespace Application.Profiles;

public class DisciplinaProfile : Profile
{
    public DisciplinaProfile()
    {
        CreateMap<Disciplina, DisciplinaDto>();
        CreateMap<CreateDisciplinaDto, Disciplina>();
        CreateMap<DisciplinaDto, Disciplina>();
    }
}