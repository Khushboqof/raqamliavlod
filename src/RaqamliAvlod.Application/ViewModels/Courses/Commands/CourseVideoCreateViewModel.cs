using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.Application.ViewModels.Courses.Commands
{
    public class CourseVideoCreateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string YouTubeThumbnail { get; set; } = string.Empty;
        public string YouTubeLink { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long CourseId { get; set; }

        public static implicit operator CourseVideo(CourseVideoCreateViewModel courseVideoCreateViewModel)
        {
            return new CourseVideo()
            {
                Title = courseVideoCreateViewModel.Title,
                YouTubeThumbnail = courseVideoCreateViewModel.YouTubeThumbnail,
                YouTubeLink = courseVideoCreateViewModel.YouTubeLink,
                Description = courseVideoCreateViewModel.Description,
                CourseId = courseVideoCreateViewModel.CourseId,
            };
        }
    }
}
