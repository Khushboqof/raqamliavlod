using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;

public interface ICourseService
{
    Task<bool> CreateAsync(long userId, CourseCreateDto dto);
    Task<bool> UpdateAsync(long userId, CourseUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<CourseViewModel> GetAsync(long id);
    Task<IEnumerable<CourseViewModel>> GetAllAsync(PaginationParams @params);
}
