using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Domain;

public class User : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public ICollection<Series> Series { get; set; } = new List<Series>();

    public User() : base()
    {
    }
}