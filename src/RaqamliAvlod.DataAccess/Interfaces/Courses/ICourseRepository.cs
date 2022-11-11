using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.DataAccess.Interfaces.Courses
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<PagedList<Course>> SearchAsync(string text, PaginationParams @params);
        Task<PagedList<CourseViewModel>> SearchByTitleAsync(string text, PaginationParams @params);
        Task<PagedList<CourseViewModel>> GetAllViewAsync(PaginationParams @params);
        Task<CourseViewModel?> GetViewAsync(long id);
    }
}
