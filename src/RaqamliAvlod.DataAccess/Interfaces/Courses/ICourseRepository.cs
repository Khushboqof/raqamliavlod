using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.DataAccess.Interfaces.Courses
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<PagedList<Course>> SearchAsync(string text, PaginationParams @params);
    }
}
