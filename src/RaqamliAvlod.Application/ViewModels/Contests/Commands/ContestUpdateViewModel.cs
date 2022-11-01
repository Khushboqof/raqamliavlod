using RaqamliAvlod.Domain.Entities.Contests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Contests.Commands
{
    public class ContestUpdateViewModel
    {
        [Required, MinLength(5)]
        public string Title { get; set; } = String.Empty;

        [Required]
        public string Description { get; set; } = String.Empty;

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsPublic { get; set; }

        public static implicit operator ContestUpdateViewModel(Contest contest)
        {
            return new ContestUpdateViewModel()
            {
                Title = contest.Title,
                Description = contest.Description,
                StartDate = contest.StartDate,
                EndDate = contest.EndDate,
                IsPublic = contest.IsPublic
            };
        }
    }
}
