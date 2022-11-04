using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Users;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("registrate"), AllowAnonymous]
    public async Task<IActionResult> RegistrateAsync([FromForm] AccountCreateDto accountCreateViewModel)
        => Ok(await _accountService.RegisterAsync(accountCreateViewModel));

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] AccountLoginDto accountLoginViewModel)
        => Ok(await _accountService.LogInAsync(accountLoginViewModel));

    [HttpPost("verifyemail")]
    public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDto verifyEmail)
        => Ok(await _accountService.VerifyEmailAsync(verifyEmail));
}
