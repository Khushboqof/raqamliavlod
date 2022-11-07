using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly ICourseVideoService _courseVideoService;

    public CoursesController(ICourseService courseService,
        ICourseVideoService courseVideoService)
    {
        _courseService = courseService;
        _courseVideoService = courseVideoService;
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
    {
        return Ok();
    }

    [HttpGet("{courseId}/comments")]
    public async Task<IActionResult> GetAllCommentsAsync([FromQuery] PaginationParams @params, long courseId)
    {
        return Ok();
    }

    [HttpDelete("{courseId}/comments/{commentId}")]
    public async Task<IActionResult> DeleteCommentAsync(long courseId, long commentId)
    {
        return Ok();
    }

    [HttpGet("search/{search}")]
    public async Task<IActionResult> SearchAsync([FromQuery] PaginationParams @params, string search)
    {
        return Ok();
    }

    [HttpDelete("videos")]
    public async Task<IActionResult> DeleteVideosAsync(long id)
    {
        return Ok();
    }

    [HttpPost("videos")]
    public async Task<IActionResult> CreateCourseVideoAsync([FromForm] CourseVideoCreateDto dto)
        => Ok(await _courseVideoService.CreateAsync(dto));

    [HttpPatch("videos")]
    public async Task<IActionResult> UpdateCourseVideoAsync(long id, string link)
    {
        return Ok();
    }
    [HttpPost("videos/views")]
    public async Task<IActionResult> CreateViewsAsync(long id)
    {
        return Ok();
    }
}
