namespace AvonaleSimplificado.Application.Abstractions;

public interface IHashingService
{
    public string Hash(string value);

    // public Task<string> HashAsync(string value);

    public bool VerifyHash(string value, string hashed);
}
