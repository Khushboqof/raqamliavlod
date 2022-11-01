using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.Application.ViewModels.Courses.Commands
{
    public class CourseCommentCreateViewModel
    {
        public string CommentText { get; set; } = string.Empty;
        public long CourseId { get; set; }
        public long OwnerId { get; set; }

        public static implicit operator CourseComment(CourseCommentCreateViewModel courseCommentCreateViewModel)
        {
            return new CourseComment()
            {
                CommentText = courseCommentCreateViewModel.CommentText,
                CourseId = courseCommentCreateViewModel.CourseId,
                OwnerId = courseCommentCreateViewModel.OwnerId,
            };
        }

    }
}
