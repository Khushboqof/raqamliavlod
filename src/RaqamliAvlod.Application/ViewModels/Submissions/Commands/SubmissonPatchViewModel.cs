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
    public class SubmissonPatchViewModel
    {
        public string Language { get; set; } = string.Empty;

        [Required]
        public IFormFile? Code { get; set; }

        public static implicit operator SubmissonPatchViewModel(Submission submission)
        {
            return new SubmissonPatchViewModel()
            {
                Language = submission.Language,
            };
        }
    }
}
