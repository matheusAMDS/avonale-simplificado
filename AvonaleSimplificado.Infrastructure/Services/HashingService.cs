using AvonaleSimplificado.Application.Abstractions;

using static BCrypt.Net.BCrypt;

namespace AvonaleSimplificado.Infrastructure.Services;

public class HashingService : IHashingService
{
    public string Hash(string value)
    {
        return HashPassword(value);
    }

    public bool VerifyHash(string value, string hashed)
    {
        return Verify(value, hashed);
    }
}
