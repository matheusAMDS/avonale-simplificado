namespace AvonaleSimplificado.Domain.Users;

public record Password(string Value)
{
    public static Password Create(string password)
    {
        if (password.Length < 8)
        {
            throw new Exception("A senha deve conter 8 caractéres");
        }

        return new Password(password);
    }
}
