using RaqamliAvlod.Domain.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos
{
    public class CourseVideoCreateDto
    {
        [Required]
        public string Link { get; set; } = string.Empty;

        [Required]
        public long CourseId { get; set; }

        public static implicit operator CourseVideo(CourseVideoCreateDto courseVideoCreateDto)
        {
            return new CourseVideo()
            {
                CourseId = courseVideoCreateDto.CourseId
            };
        }
    }
}
