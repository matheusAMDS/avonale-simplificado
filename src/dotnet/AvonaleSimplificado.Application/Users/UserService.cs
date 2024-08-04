using AvonaleSimplificado.Application.Abstractions;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Domain.Users.Services;

namespace AvonaleSimplificado.Application.Users;

public class UserService(
    IUserRepository userRepository,
    IHashingService hashingService
) : IUserService
{
    public async Task<User?> GetUserByIdAsync(UserId id)
    {
        return await userRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await userRepository.GetUsersAsync();
    }

    public async Task<UserId> CreateUserAsync(Name name, Email email, Password password, CPF cpf)
    {
        User? existingUserWithCPF = await userRepository.GetUserByCPFAsync(cpf);
        if (existingUserWithCPF is not null)
        {
            throw new Exception("User already exists (same CPF)");
        }

        User? existingUserWithEmail = await userRepository.GetUserByCPFAsync(cpf);
        if (existingUserWithEmail is not null)
        {
            throw new Exception("User already exists (same Email)");
        }

        Password hashedPassword = new(hashingService.Hash(password.Value));
        User newUser = new(
            new UserId(Guid.NewGuid()),
            UserType.Common,
            name,
            email,
            hashedPassword,
            cpf
        );

        User storedUser = await userRepository.AddUserAsync(newUser);

        return storedUser.Id;
    }
}
