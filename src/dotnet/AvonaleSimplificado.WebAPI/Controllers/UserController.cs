using Microsoft.AspNetCore.Mvc;
using AvonaleSimplificado.WebAPI.DTO;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Domain.Users.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

    [Authorize]
    [HttpGet("MyInfo")]
    public async Task<ActionResult> GetMyUser()
    {
        var userIdRaw = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdRaw is null)
        {
            return Unauthorized();
        }

        var userId = new UserId(Guid.Parse(userIdRaw));
        var user = await userService.GetUserByIdAsync(userId);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(UserDTO.From(user));
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
