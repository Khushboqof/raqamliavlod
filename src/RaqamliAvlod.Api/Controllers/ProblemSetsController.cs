using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.ProblemSets.Commands;
using RaqamliAvlod.Application.ViewModels.Submissions.Commands;

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
    public async Task<IActionResult> UpdateAsync(long id, [FromForm] ProblemSetCreateViewModel problemSetCreateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok();
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync(string search, [FromQuery] PaginationParams @params)
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

    [HttpPost("tests")]
    public async Task<IActionResult> CreateProblemSetsTest(long testId, 
        [FromForm] ProblemSetTestCreateViewModel problemSetTestCreateViewModel)
    {
        return Ok();
    }

    [HttpPut("tests/{testId}")]
    public async Task<IActionResult> UpdateProblemSetsTestAsync(long testId, 
        [FromForm] ProblemSetTestCreateViewModel problemSetTestCreateViewModel)
    {
        return Ok();
    }

    [HttpDelete("tests/{testId}")]
    public async Task<IActionResult> DeleteProblemSetsTestAsync(long testId)
    {
        return Ok();
    }

    [HttpPost("submissions")]
    public async Task<IActionResult> CreateSubmissionAsync(ProblemSetSubmissionCreateViewModel viewModel)
    {
        return Ok();
    }

    [HttpGet("{problemSetId}/submissions")]
    public async Task<IActionResult> GetAllSubmissions(long problemSetId)
    {
        return Ok();
    }
}
