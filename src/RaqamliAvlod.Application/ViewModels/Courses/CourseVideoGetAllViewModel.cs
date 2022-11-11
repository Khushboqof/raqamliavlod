using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.Application.ViewModels.Courses
{
    public class CourseVideoGetAllViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string YouTubeThumbnail { get; set; } = string.Empty;
        public int ViewCount { get; set; }
        public string YouTubeLink { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public static implicit operator CourseVideoGetAllViewModel(CourseVideo courseVideo)
        {
            return new CourseVideoGetAllViewModel()
            {
                Id = courseVideo.Id,
                Title = courseVideo.Title,
                YouTubeThumbnail = courseVideo.YouTubeThumbnail,
                ViewCount = courseVideo.ViewCount,
                YouTubeLink = courseVideo.YouTubeLink,
                Duration = courseVideo.Duration,
                CreatedAt = courseVideo.CreatedAt
            };
        }
    }
}
