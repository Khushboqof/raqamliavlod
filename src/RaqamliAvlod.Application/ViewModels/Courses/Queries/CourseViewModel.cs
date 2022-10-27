namespace RaqamliAvlod.Application.ViewModels.Courses.Queries
{
    public class CourseViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public float Price { get; set; }

        public string OwnerName { get; set; } = string.Empty;
    }
}
