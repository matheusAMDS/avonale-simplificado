using AvonaleSimplificado.Application.Abstractions;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Domain.Users.Contracts;
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

        User? existingUserWithEmail = await userRepository.GetUserByEmailAsync(email);
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

    public async Task EditUserAsync(UserId id, EditUserContract data)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        if (data.Name is not null)
        {
            user.ChangeName(data.Name);
        }

        if (data.Email is not null && data.Email.Value != "")
        {
            user.ChangeEmail(data.Email);
        }

        var editedUser = await userRepository.UpdateAsync(user);
        if (editedUser is null)
        {
            throw new Exception("Unable to edit user");
        }

        return;
    }

    public async Task DeleteUserAsync(UserId id)
    {
        if (!await userRepository.DeleteAsync(id))
        {
            throw new Exception("Unable to delete user");
        }
    }
}
