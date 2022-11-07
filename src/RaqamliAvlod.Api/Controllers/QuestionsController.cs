using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        var result = await _questionService.GetAllAsync(@params);

        return Ok(result);
    }

    [HttpGet("{questionId}")]
    public async Task<IActionResult> GetAsync(long questionId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] QuestionCreateDto questionCreateViewModel)
    {
        return Ok();
    }

    [HttpPatch("{questionId}")]
    public async Task<IActionResult> UpdateAsync(long questionId, [FromBody] QuestionCreateDto questionUpdateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{questionId}")]
    public async Task<IActionResult> DeleteAsync(long questionId)
    {
        return Ok();
    }

    [HttpPost("{questionId}/views")]
    public async Task<IActionResult> CreateViewsAsync(long questionId)
    {
        return Ok();
    }

    [HttpPost("{questionId}/answers")]
    public async Task<IActionResult> CreateAnswerAsync(long questionId)
    {
        return Ok();
    }

    [HttpGet("answers/{answerId}")]
    public async Task<IActionResult> GetAnswerAsync(long answerId)
    {
        return Ok();
    }

    [HttpPut("answers/{answerId}")]
    public async Task<IActionResult> UpdateAnswerAsync(long answerId)
    {
        return Ok();
    }

    [HttpDelete("answers/{answerId}")]
    public async Task<IActionResult> DeleteAsnwerAsync(long answerId)
    {
        return Ok();
    }

    [HttpGet("search/{search}")]
    public async Task<IActionResult> GetSearchAsync(string search)
    {
        return Ok();
    }
}
