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
    private readonly ILogger _logger;
    public AccountsController(IAccountService accountService, ILogger logger)
    {
        _accountService = accountService;
        _logger = logger;
    }

    [HttpPost("registrate"), AllowAnonymous]
    public async Task<IActionResult> RegistrateAsync([FromForm] AccountCreateDto accountCreateViewModel)
        => Ok(await _accountService.RegisterAsync(accountCreateViewModel));

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromForm] AccountLoginDto accountLoginViewModel)
        => Ok(await _accountService.LogInAsync(accountLoginViewModel));
}
