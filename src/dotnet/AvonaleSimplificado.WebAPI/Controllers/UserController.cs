using Microsoft.AspNetCore.Mvc;
using AvonaleSimplificado.WebAPI.DTO;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.Domain.Users.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AvonaleSimplificado.Domain.Users.Contracts;

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

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> EditUser(Guid id, [FromBody] EditUserRequest dto)
    {
        try
        {
            var contract = new EditUserContract(
                new Name(dto.FirstName, dto.LastName),
                new Email(dto.Email)
            );
            var userId = new UserId(id);

            await userService.EditUserAsync(userId, contract);

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        try
        {
            await userService.DeleteUserAsync(new UserId(id));

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
