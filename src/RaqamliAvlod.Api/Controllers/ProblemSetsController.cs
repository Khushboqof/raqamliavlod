using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.ProblemSets.Commands;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/problemSets")]
[ApiController]
public class ProblemSetsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        return Ok();
    }

    [HttpGet("{problemSetId}")]
    public async Task<IActionResult> GetAsync(long problemSetId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] ProblemSetCreateViewModel problemSetCreateViewModel)
    {
        return Ok();
    }

    [HttpPut("{problemSetId}")]
    public async Task<IActionResult> UpdateAsync(long problemSetId, [FromForm] ProblemSetUpdateViewModel problemSetUpdateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{problemSetId}")]
    public async Task<IActionResult> DeleteAsync(long problemSetId)
    {
        return Ok();
    }

    [HttpGet("search/{search}")]
    public async Task<IActionResult> Search([FromQuery] PaginationParams @params, string search)
    {
        return Ok();
    }

    [HttpGet("{problemSetId}/Tests")]
    public async Task<IActionResult> GetProblemSetTests(long problemSetId)
    {
        return Ok();
    }

    [HttpGet("tests/{testId}")]
    public async Task<IActionResult> GetProblemSetsTest(long testId)
    {
        return Ok();
    }

    [HttpPut("tests/{testId}")]
    public async Task<IActionResult> UpdateProblemSetsTest(long testId, [FromBody] ProblemSetUpdateViewModel problemSetUpdateViewModel)
    {
        return Ok();
    }

    [HttpDelete("tests/{testId}")]
    public async Task<IActionResult> DeleteProblemSetsTest(long testId)
    {
        return Ok();
    }
}
