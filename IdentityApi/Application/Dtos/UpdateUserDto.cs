using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class UpdateUserDto
{
    public DateTime DataNascimento { get; set; }
    public required string Email { get; set; }
}