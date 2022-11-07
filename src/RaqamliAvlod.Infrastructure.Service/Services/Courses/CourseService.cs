using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.DataAccess.Interfaces.Courses;
using RaqamliAvlod.DataAccess.Interfaces.Users;
using RaqamliAvlod.Domain.Entities.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CourseService(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
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

            return res is not null ? true : false;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var course = await _unitOfWork.Courses.FindByIdAsync(id);

            if (course is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

            var res = await _unitOfWork.Courses.DeleteAsync(id);

            return res is not null ? true : false;
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllAsync(PaginationParams @params)
        {
            var courses = await _unitOfWork.Courses.GetAllAsync(@params);

            var courseViews = new List<CourseViewModel>();

            foreach(var course in courses)
            {
                var owner = (await _unitOfWork.Users.FindByIdAsync(course.OwnerId))!;
                var ownerView = (OwnerViewModel)owner;

                var courseView = (CourseViewModel)course;
                courseView.OwnerViewModel = ownerView;

                courseViews.Add(courseView);
            }

            return courseViews;
        }

        public async Task<IEnumerable<CourseViewModel>> SearchByTitleAsync(string text, PaginationParams @params)
        {
            var courses = await _unitOfWork.Courses.SearchAsync(text, @params);
            var courseViews = new List<CourseViewModel>();

            foreach (var course in courses)
            {
                var owner = (await _unitOfWork.Users.FindByIdAsync(course.OwnerId))!;
                var ownerView = (OwnerViewModel)owner;

                var courseView = (CourseViewModel)course;
                courseView.OwnerViewModel = ownerView;

                courseViews.Add(courseView);
            }

            return courseViews;
        }
        public async Task<CourseViewModel> GetAsync(long id)
        {
            var course = await _unitOfWork.Courses.FindByIdAsync(id);

            if (course is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

            var owner = await _unitOfWork.Users.FindByIdAsync(course.OwnerId);

            if (owner is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Owner not found!");

            var ownerView = (OwnerViewModel)owner;

            var courseView = (CourseViewModel)course;

            courseView.OwnerViewModel = ownerView;

            return courseView;
        }

        public Task<bool> UpdatePatchAsync(long courseId, CourseUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePutAsync(long courseId, CourseUpdateDto dto)
        {
            var course = _unitOfWork.Courses.FindByIdAsync(courseId);

            if (course is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Course not found!");

            var updadetCourse = (Course)dto;
            updadetCourse.Id = courseId;
            updadetCourse.ImagePath = await _fileService.SaveImageAsync(dto.Image);

            var res = await _unitOfWork.Courses.UpdateAsync(courseId, updadetCourse);

            return res is not null ? true : false;
        }
    }
}
