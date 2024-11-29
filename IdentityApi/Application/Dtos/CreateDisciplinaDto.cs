using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class CreateDisciplinaDto
{
    [Required]
    public required string Title { get; set; }
    [Required]
    public string? Semestre { get; set; }
    [Required]
    public string? Curso { get; set; }
    [Required]
    public string? Professor { get; set; }
}