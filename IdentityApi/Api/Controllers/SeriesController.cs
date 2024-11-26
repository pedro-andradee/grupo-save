using Api.AccessPolicies;
using Application.Dtos;
using IdentityApi.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Api.Controllers;

[Route("api/series")]
[ApiController]
public class SeriesController : ControllerBase
{
    private readonly SeriesService _userService;
    private readonly string _userId;

    public SeriesController(SeriesService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _userId = httpContextAccessor.HttpContext?.User?.Claims?.SingleOrDefault(c => c.Type == "id")?.Value ?? Guid.Empty.ToString();
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSeries([FromBody] CreateSeriesDto request)
    {
        var success = await _userService.CreateSeriesAsync(request, _userId);
        if (success is false)
        {
            return BadRequest("An error occurred while creating the series.");
        }
        return Created();
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSeries()
    {
        var series = await _userService.GetSeriesAsync(_userId);
        if (series == null)
        {
            return NotFound("Series not found.");
        }
        return Ok(series);
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSeriesById(Guid id)
    {
        var series = await _userService.GetSeriesByIdAsync(id, _userId);
        if (series == null)
        {
            return NotFound("Series not found.");
        }
        return Ok(series);
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSeries([FromBody] UpdateSeriesDto request)
    {
        var success = await _userService.UpdateSeriesAsync(request);
        if (success is false)
        {
            return BadRequest("An error occurred while updating the series.");
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteSeries(Guid id)
    {
        var success = await _userService.DeleteSeriesAsync(id);
        if (success is false)
        {
            return BadRequest("An error occurred while deleting the series.");
        }
        return NoContent();
    }
}