using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Domain.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvonaleSimplificado.WebAPI.Controllers;

public record SignInBody(string Email, string Password);

public record SignUpInput(string Name, string Email, string Password, string CPF);

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInBody dto)
    {
        try
        {
            var result = await _authService.SignIn(
                new Email(dto.Email), new Password(dto.Password)
            );

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}


