using Application.Dtos;
using AutoMapper;
using Domain.Repositories;
using IdentityApi.Application.Dtos;
using IdentityApi.Domain;

namespace IdentityApi.Application.Services;

public class SeriesService
{
    private readonly IMapper _mapper;
    private readonly ISeriesRepository _seriesRepository;

    public SeriesService(IMapper mapper, ISeriesRepository seriesRepository)
    {
        _mapper = mapper;
        _seriesRepository = seriesRepository;
    }

    public async Task<bool> CreateSeriesAsync(CreateSeriesDto dto, string userId)
    {
        var series = _mapper.Map<Series>(dto);
        series.UserId = userId;
        return await _seriesRepository.CreateAsync(series);
    }

    public async Task<IEnumerable<SeriesDto>> GetSeriesAsync(string userId)
    {
        var series = await _seriesRepository.GetAllAsync(userId);
        return series.Select(_mapper.Map<SeriesDto>);
    }

    public async Task<SeriesDto> GetSeriesByIdAsync(Guid id, string userId)
    {
        var series = await _seriesRepository.GetByIdAsync(id, userId);
        if (series == null)
        {
            return null;
        }
        return _mapper.Map<SeriesDto>(series);
    }

    public async Task<bool> UpdateSeriesAsync(UpdateSeriesDto dto)
    {
        var series = _mapper.Map<Series>(dto);
        return await _seriesRepository.UpdateAsync(series) != null;
    }

    public async Task<bool> DeleteSeriesAsync(Guid id)
    {
        return await _seriesRepository.DeleteAsync(id);
    }
}