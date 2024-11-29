using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Domain;

public class User : IdentityUser
{
    public DateTime DataNascimento { get; set; }

    public User() : base()
    {
    }
}