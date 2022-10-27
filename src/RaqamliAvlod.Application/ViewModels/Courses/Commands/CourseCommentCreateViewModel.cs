namespace RaqamliAvlod.Application.ViewModels.Courses.Commands
{
    public class CourseCommentCreateViewModel
    {
        public string CommentText { get; set; } = string.Empty;

        public long CourseId { get; set; }
    }
}
