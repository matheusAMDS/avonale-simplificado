using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AvonaleSimplificado.Domain.Users;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("super duper ultra top secret key of all time!")
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256Signature
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = credentials
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.Value.ToString()));
        claims.AddClaim(new Claim(ClaimTypes.Name, user.Name.FullName()));
        claims.AddClaim(new Claim(ClaimTypes.Role, user.Type.ToString()));

        return claims;
    }
}
