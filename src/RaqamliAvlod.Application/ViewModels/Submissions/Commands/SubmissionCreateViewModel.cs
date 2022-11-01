using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Domain.Entities.Submissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Submissions.Commands
{
    public class SubmissionCreateViewModel
    {
        public long ProblemSetId { get; set; }

        public string Language { get; set; } = string.Empty;

        [Required]
        public IFormFile Code { get; set; } = null!;

        public static implicit operator Submission(SubmissionCreateViewModel submissionCreateViewModel)
        {
            return new Submission()
            {
                ProblemSetId = submissionCreateViewModel.ProblemSetId,
                Language = submissionCreateViewModel.Language
            };
        }
    }
}
