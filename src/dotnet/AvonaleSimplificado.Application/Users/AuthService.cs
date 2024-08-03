using AvonaleSimplificado.Application.Abstractions;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Domain.Users.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IHashingService _hashingService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService, IHashingService hashingService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _hashingService = hashingService;
    }

    public async Task<string> SignIn(Email email, Password password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        if (!_hashingService.VerifyHash(password.Value, user.Password.Value))
        {
            throw new Exception("Incorrect password");
        }

        var token = _tokenService.GenerateToken(user);
        if (token is null)
        {
            throw new Exception("Unable to generate authorization token");
        }

        return token;
    }
}
