using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Courses
{
    public interface ICourseCommentService
    {
        Task<bool> CreateAsync(long userId, long ownerId, CourseCommentCreateDto dto);
        Task<bool> UpdateAsync(long courseCommentId, CourseCommentUpdateDto dto);
        Task<bool> DeleteAsync(long userId, long courseId, long id);
        Task<CourseCommentViewModel> GetAsync(long id);
        Task<IEnumerable<CourseCommentViewModel>> GetAllByCourseIdAsync(long courseId, PaginationParams @params);
    }
}
