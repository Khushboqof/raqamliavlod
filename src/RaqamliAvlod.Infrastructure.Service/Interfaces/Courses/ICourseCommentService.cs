using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Courses
{
    public interface ICourseCommentService
    {
        Task<bool> CreateAsync(long userId, long ownerId, CourseCommentCreateDto dto);
        Task<bool> UpdateAsync(long userId,long courseCommentId, CourseCommentUpdateDto dto);
        Task<bool> DeleteAsync(long userId, long id);
        Task<CourseCommentViewModel> GetAsync(long userId,long id);
        Task<IEnumerable<CourseCommentViewModel>> GetAllByCourseIdAsync(long userId, long courseId, PaginationParams @params);
    }
}
