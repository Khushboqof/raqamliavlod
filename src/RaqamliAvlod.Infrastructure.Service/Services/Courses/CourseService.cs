﻿using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IPaginatorService _paginator;

        public CourseService(IUnitOfWork unitOfWork,
            IFileService fileService,
            IPaginatorService paginator)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _paginator = paginator;
        }
        public async Task<bool> CreateAsync(CourseCreateDto dto)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(dto.OwnerId);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Owner not found!");
            var course = (Course)dto;

            course.ImagePath = await _fileService.SaveImageAsync(dto.Image!);
            course.CreatedAt = TimeHelper.GetCurrentDateTime();
            course.UpdatedAt = TimeHelper.GetCurrentDateTime();

            var res = await _unitOfWork.Courses.CreateAsync(course);

            return res is not null;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var course = await _unitOfWork.Courses.FindByIdAsync(id);

            if (course is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

            if(!string.IsNullOrEmpty(course.ImagePath))
                await _fileService.DeleteImageAsync(course.ImagePath);

            var res = await _unitOfWork.Courses.DeleteAsync(id);

            return res is not null;
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllAsync(PaginationParams @params)
        {
            var courses = await _unitOfWork.Courses.GetAllViewAsync(@params);
            _paginator.ToPagenator(courses.MetaData);

            return courses;
        }

        public async Task<IEnumerable<CourseViewModel>> SearchByTitleAsync(string text, PaginationParams @params)
        {
            var courseViews = await _unitOfWork.Courses.SearchByTitleAsync(text, @params);
            _paginator.ToPagenator(courseViews.MetaData);

            return courseViews;
        }
        public async Task<CourseViewModel> GetAsync(long id)
        {
            var course = await _unitOfWork.Courses.GetViewAsync(id);

            if (course is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

            return course;
        }


        public async Task<bool> UpdateAsync(long courseId, CourseUpdateDto dto)
        {
            var course = await _unitOfWork.Courses.FindByIdAsync(courseId);

            if (course is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

            var updadetCourse = (Course)dto;

            if (dto.Image is not null)
            {
                await _fileService.DeleteImageAsync(course.ImagePath);
                updadetCourse.ImagePath = await _fileService.SaveImageAsync(dto.Image);
            }

            updadetCourse.Id = courseId;
            updadetCourse.CreatedAt = course.CreatedAt;
            updadetCourse.UpdatedAt = TimeHelper.GetCurrentDateTime();

            var result = await _unitOfWork.Courses.UpdateAsync(courseId, updadetCourse);
            return result is not null;
        }
    }
}
