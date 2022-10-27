using RaqamliAvlod.Domain.Entities.Contests;
using RaqamliAvlod.Domain.Entities.ProblemSets;
using RaqamliAvlod.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Submissions.Queries
{
    public class SubmissionViewModel
    {
        public string Result { get; set; } = String.Empty;
        public string Language { get; set; } = String.Empty;
        public int ExecutionTime { get; set; }
        public int MemoryUsage { get; set; }
        public int LengthOfCode { get; set; }

        public string Username { get; set; } = string.Empty;
        
        public long ProblemSetId { get; set; }
        public long? ContestId { get; set; }
    }
}
