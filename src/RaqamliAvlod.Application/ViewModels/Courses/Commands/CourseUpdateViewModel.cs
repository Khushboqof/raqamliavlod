using RaqamliAvlod.Domain.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Courses.Commands
{
    public class CourseUpdateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public float Price { get; set; }

        public long OwnerId { get; set; }

        public static implicit operator CourseUpdateViewModel(Course course)
        {
            return new CourseUpdateViewModel()
            {
                Title = course.Title,
                Info = course.Info,
                Type = course.Type,
                ImagePath = course.ImagePath,
                Price = course.Price,
                OwnerId = course.OwnerId
            };
        }
    }
}
