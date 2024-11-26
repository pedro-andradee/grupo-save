using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApi.Application.Dtos;

public class CreateUserDto
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    [Required]
    [Compare("Password")]
    public required string PasswordConfirmation { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public required string Email { get; set; }
}