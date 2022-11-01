using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Domain.Entities.Submissions;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Application.ViewModels.Submissions.Commands
{
    public class ContestSubmissionCreateViewModel
    {
        [Required]
        public long ContestId { get; set; }
        
        [Required]
        public long ProblemSetId { get; set; }
        
        [Required]
        public string Language { get; set; } = string.Empty;
        
        [Required]
        public IFormFile Code { get; set; } = null!;

        public static implicit operator Submission(ContestSubmissionCreateViewModel contestSubmissionCreateViewModel)
        {
            return new Submission()
            {
                ContestId = contestSubmissionCreateViewModel.ContestId,
                ProblemSetId = contestSubmissionCreateViewModel.ProblemSetId,
                Language = contestSubmissionCreateViewModel.Language,
            };
        }
    }
}
