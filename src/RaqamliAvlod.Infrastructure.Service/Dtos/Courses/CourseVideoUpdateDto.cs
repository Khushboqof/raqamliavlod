using RaqamliAvlod.Domain.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos
{
    public class CourseVideoUpdateDto
    {
        [Required]
        public string Link { get; set; } = string.Empty;
    }
}
