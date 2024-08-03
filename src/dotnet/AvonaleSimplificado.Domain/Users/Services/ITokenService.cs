using AvonaleSimplificado.Domain.Users;

public interface ITokenService
{
    public string GenerateToken(User user);
}
