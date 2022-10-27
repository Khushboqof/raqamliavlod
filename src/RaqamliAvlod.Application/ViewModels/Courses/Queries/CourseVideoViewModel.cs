using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Courses.Queries
{
    public class CourseVideoViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string YouTubeThumbnail { get; set; } = string.Empty;
        public int ViewCount { get; set; }
        public string YouTubeLink { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;
    }
}
