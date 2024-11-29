using Application.Dtos;
using IdentityApi.Application.Dtos;
using IdentityApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Api.Controllers;

public class DisciplinaController : Controller
{
    private readonly DisciplinaService _disciplinaService;

    public DisciplinaController(DisciplinaService disciplinaService)
    {
        _disciplinaService = disciplinaService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var disciplinas = await _disciplinaService.GetDisciplinasAsync();
        return View(disciplinas);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDisciplinaDto createDisciplinaDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createDisciplinaDto);
        }

        var success = await _disciplinaService.CreateDisciplinaAsync(createDisciplinaDto);
        if (!success)
        {
            ModelState.AddModelError("", "Ocorreu um erro ao criar a disciplina.");
            return View(createDisciplinaDto);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpGet("Detalhes/{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
        var disciplina = await _disciplinaService.GetDisciplinaByIdAsync(id);
        if (disciplina == null)
        {
            return NotFound();
        }

        return View(disciplina);
    }

    [HttpGet("Editar/{id}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var disciplina = await _disciplinaService.GetDisciplinaByIdAsync(id);
        if (disciplina == null)
        {
            return NotFound();
        }

        return View(disciplina);
    }


    [HttpPost("Editar/{id}")]
    public async Task<IActionResult> Edit(Guid id, DisciplinaDto request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var success = await _disciplinaService.UpdateDisciplinaAsync(request);
        if (!success)
        {
            ModelState.AddModelError("", "Ocorreu um erro ao atualizar a disciplina.");
            return View(request);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Excluir/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var disciplina = await _disciplinaService.GetDisciplinaByIdAsync(id);
        if (disciplina == null)
        {
            return NotFound("Disciplina não encontrada.");
        }

        return View(disciplina);
    }

    [HttpPost("Excluir/{id}")]
    public async Task<IActionResult> Delete(Guid id, DisciplinaDto request)
    {
        var success = await _disciplinaService.DeleteDisciplinaAsync(id);
        if (!success)
        {
            return BadRequest("Ocorreu um erro ao deletar a disciplina.");
        }

        return RedirectToAction(nameof(Index));
    }
}
