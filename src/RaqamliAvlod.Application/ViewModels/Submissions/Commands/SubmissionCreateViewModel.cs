using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Submissions.Commands
{
    public class SubmissionCreateViewModel
    {
        public IFormFile Code { get; set; }
        public string Language { get; set; } = string.Empty;
        public long ProblemSetId { get; set; }
        public long? ContestId { get; set; } 
    }
}
