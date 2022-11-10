using RaqamliAvlod.Domain.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos
{
    public class CourseCommentCreateDto
    {
        [Required, MinLength(3)]
        public string CommentText { get; set; } = string.Empty;

        public static implicit operator CourseComment(CourseCommentCreateDto courseCommentCreateDto)
        {
            return new CourseComment()
            {
                CommentText = courseCommentCreateDto.CommentText
            };
        }

    }
}
