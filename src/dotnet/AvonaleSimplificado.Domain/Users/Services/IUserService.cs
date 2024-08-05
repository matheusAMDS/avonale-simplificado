using AvonaleSimplificado.Domain.Users.Contracts;

namespace AvonaleSimplificado.Domain.Users.Services;

public interface IUserService
{
    public Task<UserId> CreateUserAsync(Name name, Email email, Password password, CPF cpf);

    public Task<User?> GetUserByIdAsync(UserId id);

    public Task<IEnumerable<User>> GetAllUsersAsync();

    public Task EditUserAsync(UserId id, EditUserContract user);

    public Task DeleteUserAsync(UserId id);
}
