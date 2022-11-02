using CodePower.DataAccess.Common;
using RaqamliAvlod.Domain.Entities.Courses;
using System;

namespace RaqamliAvlod.DataAccess.Interfaces.Courses
{
    public interface ICourseVideoRepository : IRepository<CourseVideo>
    {
        public Task<PagedList<CourseVideo>> GetAllByCourseIdAsync(long courseId);
    }
}