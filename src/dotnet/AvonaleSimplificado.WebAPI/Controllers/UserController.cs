using Microsoft.AspNetCore.Mvc;
using AvonaleSimplificado.WebAPI.DTO;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Domain.Users.Services;
using Microsoft.AspNetCore.Authorization;

namespace AvonaleSimplificado.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsersAsync();
        return Ok(users.Select(UserDTO.From));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest dto)
    {
        try
        {
            var result = await userService.CreateUserAsync(
                new Name(dto.FirstName, dto.LastName),
                new Email(dto.Email),
                new Password(dto.Password),
                new CPF(dto.CPF)
            );

            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
