using AvonaleSimplificado.Domain.Accounts.Services;
using AvonaleSimplificado.Domain.Users;
using AvonaleSimplificado.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("[controller]")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAccount(CreateAccountRequest dto)
    {
        try
        {
            var userId = new UserId(dto.UserId);

            var accountId = await accountService.CreateAccountAsync(userId);

            return Ok(accountId.Value);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
