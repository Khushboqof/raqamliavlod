using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly IQuestionAnswerService _questionAnswerService;
    private readonly ITagService _tagService;
    private readonly IIdentityHelperService _identityHelper;

    public QuestionsController(IQuestionService questionService,
        IQuestionAnswerService questionAnswerService,
        ITagService tagService,
        IIdentityHelperService identityHelper)
    {
        _questionService = questionService;
        this._questionAnswerService = questionAnswerService;
        this._tagService = tagService;
        this._identityHelper = identityHelper;
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _questionService.GetAllAsync(@params));

    [HttpGet("{questionId}"), AllowAnonymous]
    public async Task<IActionResult> GetAsync(long questionId)
        => Ok(await _questionService.GetAsync(questionId));

    [HttpPost, Authorize(Roles = "Admin, User, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] QuestionCreateDto questionCreateViewModel)
        => Ok(await _questionService.CreateAsync(questionCreateViewModel, _identityHelper.GetUserId()));

    [HttpPut("{questionId}"), Authorize(Roles = "Admin, User, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync(long questionId,
        [FromForm] QuestionCreateDto questionUpdateViewModel) 
        => Ok(await _questionService.UpdateAsync(questionId, questionUpdateViewModel, _identityHelper.GetUserId()));

    [HttpDelete("{questionId}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(long questionId) 
        => Ok(await _questionService.DeleteAsync(questionId, _identityHelper.GetUserId(), _identityHelper.GetUserRole()));

    [HttpPost("{questionId}/views")]
    public async Task<IActionResult> CreateViewsAsync(long questionId)
    {
        return Ok();
    }

    [HttpPost("answers"), Authorize(Roles = "Admin, User, SuperAdmin")]
    public async Task<IActionResult> CreateAnswerAsync([FromForm] QuestionAnswerCreateDto questionAnswerCreateDto)
        => Ok(await _questionAnswerService.CreateAsync(questionAnswerCreateDto, _identityHelper.GetUserId()));

    //[HttpGet("answers/{answerId}")]
    //public async Task<IActionResult> GetAnswerAsync(long answerId)
    //{
    //    return Ok();
    //}

    [HttpGet("answers/{questionId}"), AllowAnonymous]
    public async Task<IActionResult> GetAllAsync(long questionId, [FromQuery] PaginationParams @params)
       => Ok(await _questionAnswerService.GetAllAsync(questionId, @params));

    [HttpPut("answers/{answerId}"), Authorize(Roles = "Admin, User, SuperAdmin")]
    public async Task<IActionResult> UpdateAnswerAsync(long answerId, [FromForm] QuestionAnswerUpdateDto questionAnswerUpdateDto)
       => Ok(await _questionAnswerService.UpdateAsync(answerId, questionAnswerUpdateDto, _identityHelper.GetUserId()));

    [HttpDelete("answers/{answerId}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsnwerAsync(long answerId)
        => Ok(await _questionAnswerService.DeleteAsync(answerId, _identityHelper.GetUserId(), _identityHelper.GetUserRole()));

    [HttpGet("search/{search}")]
    public async Task<IActionResult> GetSearchAsync(string search)
    {
        return Ok();
    }

    [HttpPost("tags"), Authorize(Roles = "User, Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] TagCreateDto tag)
        => Ok(await _tagService.CreateAsync(tag, _identityHelper.GetUserRole()));

    [HttpDelete("tag/{tagId}"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteTagAsync(long tagId)
        => Ok(await _tagService.DeleteAsync(tagId));

    [HttpPut("tags/{tagId}"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateTagAsync(long tagId, [FromForm] TagCreateDto updateDto)
        => Ok(await _tagService.UpdateAsync(tagId, updateDto));

    [HttpGet("tags/{tagId}"), AllowAnonymous]
    public async Task<IActionResult> GetByTagIdAsync(long tagId)
        => Ok(await _tagService.GetByIdAsync(tagId));

    [HttpGet("tags/search"), AllowAnonymous]
    public async Task<IActionResult> GetByTagNameAsync([FromQuery] string name)
        => Ok(await _tagService.GetByNameAsync(name));
}
