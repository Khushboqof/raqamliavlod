using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Courses;
using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.DataAccess.Repositories.Courses
{
    public class CourseVideoRepository : BaseRepository<CourseVideo>, ICourseVideoRepository
    {
        public CourseVideoRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<PagedList<CourseVideoGetAllViewModel>> GetAllByCourseIdAsync(long courseId, PaginationParams @params)
        {
            var query = _dbSet.Where(video => video.CourseId == courseId)
                        .OrderByDescending(x => x.Id).Select(course => (CourseVideoGetAllViewModel)course);
            return await PagedList<CourseVideoGetAllViewModel>.ToPagedListAsync(query, @params.PageNumber, @params.PageSize);
        }
    }
}
