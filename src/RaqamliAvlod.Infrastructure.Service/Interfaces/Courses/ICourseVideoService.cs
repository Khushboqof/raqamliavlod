using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;

public interface ICourseVideoService
{
    Task<bool> CreateAsync(CourseVideoCreateDto dto);
    Task<bool> UpdateAsync(long videoId, CourseVideoUpdateDto dto);
    Task<bool> DeleteAsync(long videoId);
    Task<IEnumerable<CourseVideoGetAllViewModel>> GetAllAsync(long courseId, PaginationParams @params);
    Task<CourseVideoGetViewModel> GetAsync(long videoId);

}
