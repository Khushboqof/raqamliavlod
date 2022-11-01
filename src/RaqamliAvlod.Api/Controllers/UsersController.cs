using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Users.Commands;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromBody] PaginationParams @params)
    {
        return Ok();
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAsync(long userId)
    {
        return Ok();
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateViewModel userUpdateViewModel)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] UserCreateViewModel userCreateViewModel)
    {
        return Ok();
    }

    [HttpGet("search/{search}")]
    public async Task<IActionResult> SearchAsync([FromQuery] PaginationParams @params, string search)
    {
        return Ok();
    }

    [HttpGet("{userId}/submuissions")]
    public async Task<IActionResult> GetSubmissionsAsync(long userId, [FromQuery] PaginationParams @params)
    {
        return Ok();
    }
}
