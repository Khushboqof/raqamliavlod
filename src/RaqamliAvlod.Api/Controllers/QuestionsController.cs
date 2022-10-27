using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions.Commands;
#pragma warning disable
namespace RaqamliAvlod.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        return Ok();
    }

    [HttpGet("{questionId}"), AllowAnonymous]
    public async Task<IActionResult> GetAsync(long questionId)
    {
        return Ok();
    }

    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> CreateAsync([FromForm] QuestionCreateViewModel questionCreateViewModel)
    {
        return Ok();
    }

    [HttpPatch("{questionId}"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> UpdateAsync([FromBody] QuestionCreateViewModel questionUpdateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{questionId}"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok();
    }
}
