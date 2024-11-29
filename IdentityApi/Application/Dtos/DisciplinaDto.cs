namespace IdentityApi.Application.Dtos;

public class DisciplinaDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Semestre { get; set; }
    public string? Curso { get; set; }
    public string? Professor { get; set; }
}