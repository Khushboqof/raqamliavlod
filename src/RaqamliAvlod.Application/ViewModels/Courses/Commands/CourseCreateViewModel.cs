using RaqamliAvlod.Domain.Entities.Courses;

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

        public static implicit operator Course(CourseCreateViewModel courseCreateViewModel)
        {
            return new Course()
            {
                Title = courseCreateViewModel.Title,
                Info = courseCreateViewModel.Info,
                Type = courseCreateViewModel.Type,
                ImagePath = courseCreateViewModel.ImagePath,
                Price = courseCreateViewModel.Price,
                OwnerId = courseCreateViewModel.OwnerId
            };
        }
    }
}
