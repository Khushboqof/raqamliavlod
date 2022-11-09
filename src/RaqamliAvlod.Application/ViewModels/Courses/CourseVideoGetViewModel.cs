using RaqamliAvlod.Domain.Entities.Courses;

namespace RaqamliAvlod.Application.ViewModels.Courses;

public class CourseVideoGetViewModel : CourseVideoGetAllViewModel
{    public string Description { get; set; } = string.Empty;


    public static implicit operator CourseVideoGetViewModel(CourseVideo courseVideo)
    {
        return new CourseVideoGetViewModel()
        {
            Id = courseVideo.Id,
            Title = courseVideo.Title,
            YouTubeThumbnail = courseVideo.YouTubeThumbnail,
            ViewCount = courseVideo.ViewCount,
            YouTubeLink = courseVideo.YouTubeLink,
            Description = courseVideo.Description,
            CreatedAt = courseVideo.CreatedAt
        };
    }
}
