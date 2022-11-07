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

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    /*    [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, string searchText)
        {
            var res = await _courseService.SearchByTitleAsync(searchText, @params);

            return Ok(res);
        }*/

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto courseCreateDto)
    {
        var res = await _courseService.CreateAsync(courseCreateDto);

        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        var res = await _courseService.GetAllAsync(@params);

        return Ok(res);
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetAsync(long courseId)
    {
        var res = await _courseService.GetAsync(courseId);

        return Ok(res);
    }

    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseUpdateDto updateDto)
    {
        var res = await _courseService.UpdateAsync(courseId, updateDto);

        return Ok(res);
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteAsync(long courseId)
    {
        var res = await _courseService.DeleteAsync(courseId);

        return Ok(res);
    }







    [HttpPost("{courseId}/comments")]
    public async Task<IActionResult> CreateCommentAsync(long courseId, [FromBody] CourseCommentCreateDto courseCommentCreateViewModel)
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
    public async Task<IActionResult> CreateCourseVideoAsync([FromForm] CourseVideoCreateDto courseVideoCreateViewModel)
    {
        return Ok();
    }

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
