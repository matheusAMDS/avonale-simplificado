namespace AvonaleSimplificado.Domain.Users;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUsersAsync();

    public Task<User?> GetUserByIdAsync(UserId id);

    public Task<User?> GetUserByCPFAsync(CPF cpf);

    public Task<User?> GetUserByEmailAsync(Email email);

    public Task<User> AddUserAsync(User user);
}
