namespace AvonaleSimplificado.Domain.Users;

public class User
{
    public UserId Id { get; private set; }

    public UserType Type { get; private set; }

    public Name Name { get; private set; }

    public Email Email { get; private set; }

    public Password Password { get; private set; }

    public CPF CPF { get; private set; }

    public User() { }

    public User(UserId id, UserType type, Name name, Email email, Password password, CPF cpf)
    {
        Id = id;
        Type = type;
        Name = name;
        Email = email;
        Password = password;
        CPF = cpf;
    }

    public void ChangeName(Name name)
    {
        Name = name;
    }

    public void ChangeEmail(Email email)
    {
        Email = email;
    }

    public void ChangePassword(Password password)
    {
        Password = password;
    }
}
