using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Domain;

public class Disciplina
{
    public Guid Id { get; set; }

    [Required]
    public required string Title { get; set; }
    [Required]
    public string? Semestre { get; set; }
    [Required]
    public string? Curso { get; set; }
    [Required]
    public string? Professor { get; set; }
}