namespace AvonaleSimplificado.Domain.Users.Services;

public interface IAuthService
{
    public Task<string> SignIn(Email email, Password password);
}
