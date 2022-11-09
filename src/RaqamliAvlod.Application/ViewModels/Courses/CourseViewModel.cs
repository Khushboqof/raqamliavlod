using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.Application.ViewModels.Courses
{
    public class CourseViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public OwnerViewModel Owner { get; set; } = null!;

        public static implicit operator CourseViewModel(Course course)
        {
            return new CourseViewModel()
            {
                Id = course.Id,
                Title = course.Title,
                Info = course.Info,
                Type = course.Type,
                ImagePath = course.ImagePath,
                Price = course.Price,
                CreatedAt = course.CreatedAt,
                UpdatedAt = course.UpdatedAt
            };
        }
    }
}
