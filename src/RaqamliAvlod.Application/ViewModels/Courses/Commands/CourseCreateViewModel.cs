namespace RaqamliAvlod.Application.ViewModels.Courses.Commands
{
    public class CourseCreateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public float Price { get; set; }

        public long OwnerId { get; set; }
    }
}
