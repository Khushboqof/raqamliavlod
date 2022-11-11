using CodePower.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Application.ViewModels.Users;
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

        public async Task<PagedList<CourseViewModel>> GetAllViewAsync(PaginationParams @params)
        {
            var query = _dbcontext.Courses.Include(p => p.Owner)
                        .OrderByDescending(p => p.Id).Select(p => (CourseViewModel)p);

            return await PagedList<CourseViewModel>.ToPagedListAsync(query, 
                @params.PageNumber, @params.PageSize);
        }

        public async Task<CourseViewModel?> GetViewAsync(long id)
        {
            var query = await _dbcontext.Courses.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == id);            
            if(query is null)
                return null;
            return (CourseViewModel)query;
        }
        public async Task<PagedList<Course>> SearchAsync(string text, PaginationParams @params)
        {
            return await PagedList<Course>.ToPagedListAsync(
                _dbSet.Where(course => course.Title.ToLower().Contains(text.ToLower()))
                      .OrderBy(x => x.Id),
                @params.PageNumber, @params.PageSize);
        }

        public async Task<PagedList<CourseViewModel>> SearchByTitleAsync(string text, PaginationParams @params)
        {
            var query = from course in _dbcontext.Courses.Include(course => course.Owner)
                        join owner in _dbcontext.Users on course.OwnerId equals owner.Id
                        where course.Title.ToLower().Contains(text.ToLower())
                        select (CourseViewModel)course;

            return await PagedList<CourseViewModel>.ToPagedListAsync(query, @params.PageNumber, @params.PageSize);
        }
    }
}
