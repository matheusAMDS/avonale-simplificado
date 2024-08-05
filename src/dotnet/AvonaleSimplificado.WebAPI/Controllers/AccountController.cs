using System.Security.Claims;
using AvonaleSimplificado.Domain.Accounts;
using AvonaleSimplificado.Domain.Accounts.Services;
using AvonaleSimplificado.Domain.Common;
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

    [HttpGet("{id}/Extract")]
    public async Task<ActionResult<AccountExtractResponse>> AccountExtract(Guid id, [FromQuery] AccountExtractRequest request)
    {
        try
        {
            var extract = await accountService.GetAccountExtract(
                new AccountId(id),
                request.FromDate,
                request.ToDate
            );

            return AccountExtractResponse.From(extract);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("Me")]
    public async Task<ActionResult<AccountDTO?>> AccountInfo()
    {
        try
        {
            var userIdRaw = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdRaw is null)
            {
                return Unauthorized();
            }

            var userId = new UserId(Guid.Parse(userIdRaw));

            var account = await accountService.GetAccountFromUserAsync(userId);

            if (account is null) return NotFound();

            return Ok(AccountDTO.From(account));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{to}/Deposit")]
    public async Task<ActionResult> MakeDeposit(Guid to, [FromBody] MakeDepositRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await accountService.MakeDepositAsync(
                new AccountId(to),
                new Money(request.Amount),
                cancellationToken);

            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{to}/Transfer")]
    public async Task<ActionResult> MakeTransfer(Guid to, [FromBody] MakeTransferRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await accountService.MakeTransferAsync(
                new AccountId(request.FromAccount),
                new AccountId(to),
                new Money(request.Amount),
                cancellationToken
            );

            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
