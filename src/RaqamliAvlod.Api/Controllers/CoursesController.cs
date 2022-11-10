using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Domain.Entities.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly ICourseVideoService _courseVideoService;
    private readonly ICourseCommentService _courseCommentService;
    private readonly IIdentityHelperService _identityHelper;

    public CoursesController(ICourseService courseService,
        ICourseVideoService courseVideoService, ICourseCommentService courseCommentService,
        IIdentityHelperService identityHelper)
    {
        _courseService = courseService;
        _courseVideoService = courseVideoService;
        _courseCommentService = courseCommentService;
        _identityHelper = identityHelper;
    }

    [HttpPost, Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto courseCreateDto)
        => Ok(await _courseService.CreateAsync(courseCreateDto));

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _courseService.GetAllAsync(@params));

    [HttpGet("search"), AllowAnonymous]
    public async Task<IActionResult> SearchByTitleAsync([FromQuery] string title, [FromQuery] PaginationParams @params)
        => Ok(await _courseService.SearchByTitleAsync(title, @params));

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetAsync(long courseId)
        => Ok(await _courseService.GetAsync(courseId));

    [HttpPut("{courseId}"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseUpdateDto updateDto)
        => Ok(await _courseService.UpdateAsync(courseId, updateDto));

    [HttpDelete("{courseId}"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(long courseId)
        => Ok(await _courseService.DeleteAsync(courseId));


    [HttpPost("{courseId}/comments"), Authorize(Roles = "User, Admin, SuperAdmin")]
    public async Task<IActionResult> CreateCommentAsync(long courseId,
        [FromBody] CourseCommentCreateDto courseCommentCreateViewModel)
         => Ok(await _courseCommentService.CreateAsync((long)_identityHelper.GetUserId()!, courseId, courseCommentCreateViewModel));
    
    [HttpGet("{courseId}/comments"), Authorize(Roles = "User, Admin, SuperAdmin")]
    public async Task<IActionResult> GetAllCommentsAsync([FromQuery] PaginationParams @params, long courseId)
        => Ok(await _courseCommentService.GetAllByCourseIdAsync(_identityHelper.GetUserId(),courseId, @params));
    
    [HttpDelete("comments/{commentId}"), Authorize(Roles = "User, Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteCommentAsync( long commentId)
       => Ok(await _courseCommentService.DeleteAsync((long)_identityHelper.GetUserId()!, commentId));
    
    [HttpPut("comments/{commentId}"), Authorize(Roles = "User, Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateCommentAsync(long commentId, CourseCommentUpdateDto dto)
       => Ok(await _courseCommentService.UpdateAsync((long)_identityHelper.GetUserId()!, commentId, dto));

    [HttpPost("videos"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateCourseVideoAsync([FromForm] CourseVideoCreateDto dto)
        => Ok(await _courseVideoService.CreateAsync(dto));

    [HttpGet("{courseId}/videos")]
    public async Task<IActionResult> GetAllCourseVideoAsync(long courseId, [FromQuery] PaginationParams @params)
        => Ok(await _courseVideoService.GetAllAsync(courseId, @params));

    [HttpGet("videos/{videoId}")]
    public async Task<IActionResult> GetCourseVideoAsync(long videoId)
        => Ok(await _courseVideoService.GetAsync(videoId));

    [HttpPut("videos/{videoId}"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateCourseVideoAsync(long videoId, [FromForm]CourseVideoUpdateDto dto)
        => Ok(await _courseVideoService.UpdateAsync(videoId, dto));

    [HttpDelete("videos/{videoId}"), Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteVideosAsync(long videoId)
        => Ok(await _courseVideoService.DeleteAsync(videoId));
}
