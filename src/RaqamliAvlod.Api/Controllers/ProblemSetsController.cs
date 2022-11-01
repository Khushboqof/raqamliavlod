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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] ProblemSetCreateViewModel problemSetCreateViewModel)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromForm] ProblemSetUpdateViewModel problemSetUpdateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
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
    public async Task<IActionResult> UpdateProblemSetsTest(long testId, [FromBody] )
    {
        return Ok();
    }

    [HttpDelete("tests/{testId}")]
    public async Task<IActionResult> DeleteProblemSetsTest(long testId)
    {
        return Ok();
    }
}
