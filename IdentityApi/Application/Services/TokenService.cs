using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityApi.Domain;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims =
        [
            new Claim("name", user.UserName!),
            new Claim("id", user.Id.ToString()),
            new Claim("resource_access", "IdentityUserGet"),
            new Claim("resource_access", "IdentitySeriesGet"),
            new Claim("resource_access", "IdentitySeriesGetAll"),
            new Claim("resource_access", "IdentitySeriesCreate")
        ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("J98DSA9A8HJDAS98KASD"));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: "identity",
            audience: "identity-api",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: cred);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}