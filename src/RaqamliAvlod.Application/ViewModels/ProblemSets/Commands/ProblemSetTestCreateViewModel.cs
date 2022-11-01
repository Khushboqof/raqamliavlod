using System;

namespace RaqamliAvlod.Application.ViewModels.ProblemSets.Commands
{
    public class ProblemSetTestCreateViewModel
    {
        public string Input { get; set; } = String.Empty;
        public string Output { get; set; } = String.Empty;

        public long ProblemSetId { get; set; }
    }
}