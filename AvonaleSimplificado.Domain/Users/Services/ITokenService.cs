using AvonaleSimplificado.Domain.Users.Services;

public interface ITokenService
{
    public string GenerateToken(User user);
}
