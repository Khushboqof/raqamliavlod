using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionsController : ControllerBase
{
#pragma warning disable CS1998
    private readonly IQuestionService _questionService;
    private readonly IQuestionAnswerService _questionAnswerService;
    private readonly ITagService _tagService;

    public QuestionsController(IQuestionService questionService, IQuestionAnswerService questionAnswerService, ITagService tagService)
    {
        _questionService = questionService;
        this._questionAnswerService = questionAnswerService;
        this._tagService = tagService;
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
        var result = await _questionService.GetAsync(questionId);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, User, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] QuestionCreateDto questionCreateViewModel)
    {
        var result = await _questionService.CreateAsync(questionCreateViewModel);

        return Ok(result);
    }

    [HttpPut("{questionId}")]
    [Authorize(Roles ="Admin, User, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync(long questionId, [FromBody] QuestionCreateDto questionUpdateViewModel)
    {
        var result = await _questionService.UpdateAsync(questionId, questionUpdateViewModel);

        return Ok(result);
    }

    [HttpDelete("{questionId}")]
    [Authorize(Roles = "Admin, User, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(long questionId)
    {
        var result = await _questionService.DeleteAsync(questionId);

        return Ok(result);
    }

    [HttpPost("{questionId}/views")]
    public async Task<IActionResult> CreateViewsAsync(long questionId)
    {
        return Ok();
    }

    [HttpPost("answers/create")]
    public async Task<IActionResult> CreateAnswerAsync([FromForm] QuestionAnswerCreateDto questionAnswerCreateDto)
        => Ok(await _questionAnswerService.CreateAsync(questionAnswerCreateDto));

    //[HttpGet("answers/{answerId}")]
    //public async Task<IActionResult> GetAnswerAsync(long answerId)
    //{
    //    return Ok();
    //}

    [HttpGet("answers/list")]
    public async Task<IActionResult> GetAllAsync(long id, [FromQuery] PaginationParams @params)
       => Ok(await _questionAnswerService.GetAllAsync(id, @params));

    [HttpPut("answers/{answerId}")]
    public async Task<IActionResult> UpdateAnswerAsync(long answerId, [FromForm] QuestionAnswerUpdateDto questionAnswerUpdateDto)
       => Ok(await _questionAnswerService.UpdateAsync(answerId, questionAnswerUpdateDto));

    [HttpDelete("answers/{answerId}")]
    public async Task<IActionResult> DeleteAsnwerAsync(long answerId)
        => Ok(await _questionAnswerService.DeleteAsync(answerId));

    [HttpGet("search/{search}")]
    public async Task<IActionResult> GetSearchAsync(string search)
    {
        return Ok();
    }

    [HttpPost("tags/create")]
    public async Task<IActionResult> CreateAsync(string tag)
        => Ok(await _tagService.CreateAsync(tag));

    [HttpDelete("tag/{tagId}")]
    public async Task<IActionResult> DeleteTagAsync(long tagId)
        => Ok(await _tagService.DeleteAsync(tagId));

    [HttpPut("tags/{tagId}")]
    public async Task<IActionResult> UpdateTagAsync(long tagId,[FromForm] TagCreateDto updateDto)
        => Ok(await _tagService.UpdateAsync(tagId, updateDto));

    [HttpGet("tags/{tagId}")]
    public async Task<IActionResult> GetByTagIdAsync(long tagId)
        => Ok(await _tagService.GetByIdAsync(tagId));

    [HttpGet("tags/search")]
    public async Task<IActionResult> GetByTagNameAsync([FromQuery] string name)
        => Ok(await _tagService.GetByNameAsync(name));
}
