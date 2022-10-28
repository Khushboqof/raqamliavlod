using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses.Commands;
#pragma warning disable
namespace RaqamliAvlod.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, string searchText)
    {
        return Ok();
    }

    [HttpGet("{courseId}"), AllowAnonymous]
    public async Task<IActionResult> GetAsync(long courseId)
    {
        return Ok();
    }

    [HttpPost, Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateViewModel courseCreateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{courseId}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long courseId)
    {
        return Ok();
    }

    [HttpPatch("{courseId}"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseCreateViewModel courseUpdateViewModel)
    {
        return Ok();
    }

    [HttpPost("{courseId}/Comments"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> CreateCommentAsync(long courseId, [FromBody] CourseCommentCreateViewModel courseCommentCreateViewModel)
    {
        return Ok();
    }

    [HttpGet("{courseId}/Comments"), AllowAnonymous]
    public async Task<IActionResult> GetAllCommentsAsync([FromQuery] PaginationParams @params, long courseId)
    {
        return Ok();
    }

    [HttpDelete("{courseId}/Comments/{commentId}"), Authorize(Roles = ("User, Admin"))]
    public async Task<IActionResult> DeleteCommentAsync(long courseId, long commentId)
    {
        return Ok();
    }

    [HttpGet("search/{search}"), AllowAnonymous]
    public async Task<IActionResult> SearchAsync([FromQuery] PaginationParams @params, string search)
    {
        return Ok();
    }

    [HttpPost("Videos"), AllowAnonymous]
    public async Task<IActionResult> CreateCourseVideoAsync([FromForm] CourseVideoCreateViewModel courseVideoCreateViewModel)
    {
        return Ok();
    }

    [HttpPatch("Videos"), AllowAnonymous]
    public async Task<IActionResult> UpdateCourseVideoAsync([FromForm] CourseVideoCreateViewModel courseVideoUpdateViewModel)
    {
        return Ok();
    }
}
