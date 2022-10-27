using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Contests.Commands;
#pragma warning disable
namespace RaqamliAvlod.Api.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class ContestsController : ControllerBase
{

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        return Ok();
    }

    [HttpGet("{contestId}"), AllowAnonymous]
    public async Task<IActionResult> GetAsync(long contestId)
    {
        return Ok();
    }

    [HttpPost, Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] ContestCreateViewModel contestCreateViewModel)
    {
        return Ok();
    }

    [HttpPut, Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> UpdateAsync([FromBody] ContestCreateViewModel contestUpdateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{contestId}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long contestId)
    {
        return Ok();
    }

    [HttpPost("Registrate"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> RegistrateAsync()
    {
        return Ok();
    }

    [HttpPost("Submissions"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> SubmissionsAsync()
    {
        return Ok();
    }

    [HttpPost("Standings"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> StandingsAsync(long contestId)
    {
        return Ok();
    }

    [HttpGet("{contestId}/Submissions"), AllowAnonymous]
    public async Task<IActionResult> SubmissionsAsync([FromQuery] PaginationParams @params, long contestId)
    {
        return Ok();
    }

    [HttpGet("{contestId}/Submissions/{userId}")]
    public async Task<IActionResult> SubmissionsAsync([FromQuery] PaginationParams @params, long contestId, long userId)
    {
        return Ok();
    }

    [HttpGet("{contestId}/ProblemSets")]
    public async Task<IActionResult> ProblemSetsAsync([FromQuery] PaginationParams @params, long contestId)
    {
        return Ok();
    }

    [HttpGet("{contestId}/ProblemSets/{problemSetId}")]
    public async Task<IActionResult> ProblemSetsAsync(long contestId, long problemSetId)
    {
        return Ok();
    }

    [HttpGet("{contestId}/Participants")]
    public async Task<IActionResult> ParticipantsAsync([FromQuery] PaginationParams @params, long contestId)
    {
        return Ok();
    }

    [HttpGet("{contestId}/Standings")]
    public async Task<IActionResult> StandingsAsync([FromQuery] PaginationParams @params, long contestId)
    {
        return Ok();
    }
}
