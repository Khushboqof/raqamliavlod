using Microsoft.AspNetCore.Identity;
using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Courses;
using RaqamliAvlod.Domain.Entities.Users;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Courses;

public class CourseCommentService : ICourseCommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaginatorService _paginator;

    public CourseCommentService(IUnitOfWork unitOfWork, IPaginatorService paginatorService, IIdentityHelperService identityHelper)
    {
        _unitOfWork = unitOfWork;
        _paginator = paginatorService;
    }
    public async Task<bool> CreateAsync(long userId, long courseId, CourseCommentCreateDto dto)
    {
        var user = await _unitOfWork.Users.FindByIdAsync(userId);
        var course = await _unitOfWork.Courses.FindByIdAsync(courseId);

        if (user is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Owner not found!");
        if (course is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

        var courseComment = (CourseComment)dto;
        courseComment.CourseId = courseId;
        courseComment.OwnerId = userId;
        courseComment.CreatedAt = TimeHelper.GetCurrentDateTime();
        var res = await _unitOfWork.CourseComments.CreateAsync(courseComment);

        return res is not null ? true : false;

    }

    public async Task<bool> DeleteAsync(long userId, long id)
    {
        var courseComment = await _unitOfWork.CourseComments.FindByIdAsync(id);
        var user = await _unitOfWork.Users.FindByIdAsync(userId);
        if (courseComment is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Comment not found!");
        if (courseComment.OwnerId != userId || user.Role==UserRole.Admin)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Not permitted!");
        var res = await _unitOfWork.CourseComments.DeleteAsync(id);

        return res is not null ? true : false;
    }

    public async Task<IEnumerable<CourseCommentViewModel>> GetAllByCourseIdAsync(long userId, long courseId, PaginationParams @params)
    {
        var courseComments = await _unitOfWork.CourseComments.GetAllByCourseIdAsync(courseId, @params);
        _paginator.ToPagenator(courseComments.MetaData);

        var courseCommentViews = new List<CourseCommentViewModel>();

        foreach (var courseComment in courseComments)
        {
            var owner = (await _unitOfWork.Users.FindByIdAsync(courseComment.OwnerId))!;

            var courseCommentView = (CourseCommentViewModel)courseComment;

            courseCommentView.Owner = (OwnerViewModel)owner;

            courseCommentView.IsCurrentUserIsAdmin = userId == owner.Id;

            courseCommentViews.Add(courseCommentView);
        }

        return courseCommentViews;
    }

    public async Task<CourseCommentViewModel> GetAsync(long userId, long id)
    {
        var courseComment = await _unitOfWork.CourseComments.FindByIdAsync(id);

        if (courseComment is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Course comment not found!");

        var owner = await _unitOfWork.Users.FindByIdAsync(courseComment.OwnerId);

        if (owner is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Owner not found!");

        var courseCommentView = (CourseCommentViewModel)courseComment;

        courseCommentView.IsCurrentUserIsAdmin = userId == owner.Id;

        courseCommentView.Owner = (OwnerViewModel)owner;

        return courseCommentView;
    }

    public async Task<bool> UpdateAsync(long userId, long courseCommentId, CourseCommentUpdateDto dto)
    {
        var courseComment = await _unitOfWork.CourseComments.FindByIdAsync(courseCommentId);
        var user = await _unitOfWork.Users.FindByIdAsync(userId);
        if (courseComment is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Comment not found!");
        
        if (courseComment.OwnerId != userId || user.Role == UserRole.Admin)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Not permitted!");
        
        courseComment.CommentText = dto.CommentText;

        var res = await _unitOfWork.CourseComments.UpdateAsync(courseCommentId, courseComment);

        return res is not null ? true : false;
    }
}
