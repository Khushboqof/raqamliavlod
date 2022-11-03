﻿using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, string searchText)
    {
        return Ok();
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetAsync(long courseId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto courseCreateViewModel)
    {
        return Ok();
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteAsync(long courseId)
    {
        return Ok();
    }

    [HttpPatch("{courseId}")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseCreateDto courseUpdateViewModel)
    {
        return Ok();
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
