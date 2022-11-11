using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.Application.ViewModels.Courses
{
    public class CourseCommentViewModel
    {
        public long Id { get; set; }
        public OwnerViewModel Owner { get; set; } = null!;
        public string CommentText { get; set; } = string.Empty;
        public bool IsCurrentUserIsAuthor { get; set; }
        public long CourseId { get; set; }

        public DateTime CreatedAt { get; set; }

        public static implicit operator CourseCommentViewModel(CourseComment courseComment)
        {
            return new CourseCommentViewModel()
            {
                Id = courseComment.Id,
                CommentText = courseComment.CommentText,
                CourseId = courseComment.CourseId,
                CreatedAt = courseComment.CreatedAt,
            };
        }
    }
}
