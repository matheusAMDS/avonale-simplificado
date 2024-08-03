namespace AvonaleSimplificado.Domain.Users;

public record Name(string FirstName, string LastName)
{
    public virtual string FullName()
    {
        return FirstName + " " + LastName;
    }
}
