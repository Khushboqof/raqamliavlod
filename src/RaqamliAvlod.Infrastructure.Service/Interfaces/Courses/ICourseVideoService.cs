using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Courses;

public interface ICourseVideoService
{
    Task<bool> CreateAsync(long ownerId, CourseVideoCreateDto dto);
    Task<bool> UpdateAsync(long ownerId, long courseVideoId, CourseVideoUpdateDto dto);
    Task<bool> DeleteAsync(long courseVideoId);
    Task<IEnumerable<CourseVideoViewModel>> GetAllAsync(PaginationParams @params);

}
