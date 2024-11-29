using Api.AccessPolicies;
using Application.Dtos;
using IdentityApi.Application.Dtos;
using IdentityApi.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Api.Controllers;

[Route("api/disciplinas")]
[ApiController]
public class DisciplinaController : ControllerBase
{
    private readonly DisciplinaService _disciplinaService;

    public DisciplinaController(DisciplinaService userService)
    {
        _disciplinaService = userService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDisciplina([FromBody] CreateDisciplinaDto request)
    {
        var success = await _disciplinaService.CreateDisciplinaAsync(request);
        if (success is false)
        {
            return BadRequest("Ocorreu um erro ao criar a disciplina.");
        }
        return Created();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDisciplinas()
    {
        var disciplinas = await _disciplinaService.GetDisciplinasAsync();
        if (disciplinas == null)
        {
            return NotFound("Disciplinas não encontradas.");
        }
        return Ok(disciplinas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDisciplinaById(Guid id)
    {
        var series = await _disciplinaService.GetDisciplinaByIdAsync(id);
        if (series == null)
        {
            return NotFound("Disciplina não encontrada.");
        }
        return Ok(series);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDisciplina([FromBody] DisciplinaDto request)
    {
        var success = await _disciplinaService.UpdateDisciplinaAsync(request);
        if (success is false)
        {
            return BadRequest("Aconteceu um erro ao atualizar a disciplina.");
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteDisciplina(Guid id)
    {
        var success = await _disciplinaService.DeleteDisciplinaAsync(id);
        if (success is false)
        {
            return BadRequest("Aconteceu um erro ao deletar a disciplina.");
        }
        return NoContent();
    }
}