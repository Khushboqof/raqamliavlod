using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.DataAccess.Interfaces.Courses
{
    public interface ICourseVideoRepository : IRepository<CourseVideo>
    {
        public Task<PagedList<CourseVideoGetAllViewModel>> GetAllByCourseIdAsync(long courseId, PaginationParams @params);
    }
}