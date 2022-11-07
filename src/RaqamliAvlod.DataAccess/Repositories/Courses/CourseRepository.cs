using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Courses;
using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.DataAccess.Repositories.Courses
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Course>> SearchAsync(string text, PaginationParams @params)
        {
            return await PagedList<Course>.ToPagedListAsync(
                _dbSet.Where(course => course.Title.ToLower().Contains(text.ToLower()))
                      .OrderBy(x=>x.Id), 
                @params.PageNumber, @params.PageSize);
        }
    }
}
