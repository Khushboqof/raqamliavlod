using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;
using RaqamliAvlod.Infrastructure.Service.Services.Courses;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly ICourseVideoService _courseVideoService;
    private readonly ICourseCommentService _courseCommentService;

    public CoursesController(ICourseService courseService,
        ICourseVideoService courseVideoService, ICourseCommentService courseCommentService)
    {
        _courseService = courseService;
        _courseVideoService = courseVideoService;
        _courseCommentService = courseCommentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto courseCreateDto)
        => Ok(await _courseService.CreateAsync(courseCreateDto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _courseService.GetAllAsync(@params));

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetAsync(long courseId)
        => Ok(await _courseService.GetAsync(courseId));

    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseUpdateDto updateDto)
        => Ok(await _courseService.UpdateAsync(courseId, updateDto));

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteAsync(long courseId)
        => Ok(await _courseService.DeleteAsync(courseId));

    [HttpPost("{courseId}/comments")]
    public async Task<IActionResult> CreateCommentAsync(long courseId, 
        [FromBody] CourseCommentCreateDto courseCommentCreateViewModel)
        =>Ok(await _courseCommentService.CreateAsync(courseId,courseCommentCreateViewModel));

    [HttpGet("{courseId}/comments")]
    public async Task<IActionResult> GetAllCommentsAsync([FromQuery] PaginationParams @params, long courseId)
    {
        var result = await _courseCommentService.GetAllByCourseIdAsync(courseId, @params);
        return Ok(result);
    }

    [HttpDelete("{courseId}/comments/{commentId}")]
    public async Task<IActionResult> DeleteCommentAsync(long courseId, long commentId)
    {
        var result = await _courseCommentService.DeleteAsync(courseId,commentId);
        return Ok( result);
    }

    [HttpGet("search/{search}")]
    public async Task<IActionResult> SearchAsync([FromQuery] PaginationParams @params, string search)
    {
        return Ok();
    }

    [HttpPost("videos")]
    public async Task<IActionResult> CreateCourseVideoAsync([FromForm] CourseVideoCreateDto dto)
        => Ok(await _courseVideoService.CreateAsync(dto));

    [HttpGet("{courseId}/videos")]
    public async Task<IActionResult> GetAllCourseVideoAsync(long courseId, [FromQuery]PaginationParams @params)
        => Ok(await _courseVideoService.GetAllAsync(courseId, @params));

    [HttpGet("videos/{videoId}")]
    public async Task<IActionResult> GetCourseVideoAsync(long videoId)
        => Ok(await _courseVideoService.GetAsync(videoId));

    [HttpPut("videos/{videoId}")]
    public async Task<IActionResult> UpdateCourseVideoAsync(long videoId, [FromForm]CourseVideoUpdateDto dto)
        => Ok(await _courseVideoService.UpdateAsync(videoId, dto));

    [HttpDelete("videos/{videoId}")]
    public async Task<IActionResult> DeleteVideosAsync(long videoId)
    => Ok(await _courseVideoService.DeleteAsync(videoId));
}
