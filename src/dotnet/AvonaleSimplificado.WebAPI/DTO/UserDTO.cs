using AvonaleSimplificado.Domain.Users;

namespace AvonaleSimplificado.WebAPI.DTO;

public record UserDTO(string FirstName, string LastName, string Email, string CPF)
{
    public static UserDTO From(User user)
    {
        return new UserDTO(
            user.Name.FirstName,
            user.Name.LastName,
            user.Email.Value,
            user.CPF.Value
        );
    }
};
