using Application.Dtos;
using AutoMapper;
using Domain.Repositories;
using IdentityApi.Application.Dtos;
using IdentityApi.Domain;

namespace IdentityApi.Application.Services;

public class DisciplinaService
{
    private readonly IMapper _mapper;
    private readonly IDisciplinaRepository _disciplinaRepository;

    public DisciplinaService(IMapper mapper, IDisciplinaRepository disciplinaRepository)
    {
        _mapper = mapper;
        _disciplinaRepository = disciplinaRepository;
    }

    public async Task<bool> CreateDisciplinaAsync(CreateDisciplinaDto dto)
    {
        var disciplina = _mapper.Map<Disciplina>(dto);
        return await _disciplinaRepository.CreateAsync(disciplina);
    }

    public async Task<IEnumerable<DisciplinaDto>> GetDisciplinasAsync()
    {
        var disciplina = await _disciplinaRepository.GetAllAsync();
        return disciplina.Select(_mapper.Map<DisciplinaDto>);
    }

    public async Task<DisciplinaDto> GetDisciplinaByIdAsync(Guid id)
    {
        var disciplina = await _disciplinaRepository.GetByIdAsync(id);
        if (disciplina == null)
        {
            return null;
        }
        return _mapper.Map<DisciplinaDto>(disciplina);
    }

    public async Task<bool> UpdateDisciplinaAsync(DisciplinaDto dto)
    {
        var disciplina = _mapper.Map<Disciplina>(dto);
        return await _disciplinaRepository.UpdateAsync(disciplina) != null;
    }

    public async Task<bool> DeleteDisciplinaAsync(Guid id)
    {
        return await _disciplinaRepository.DeleteAsync(id);
    }
}