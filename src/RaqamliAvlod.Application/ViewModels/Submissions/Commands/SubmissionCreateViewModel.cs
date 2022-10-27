using Microsoft.AspNetCore.Http;

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
