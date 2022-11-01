using RaqamliAvlod.Domain.Entities.ProblemSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.ProblemSets.Commands
{
    public class ProblemSetPatchViewModel
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string InputDescription { get; set; } = String.Empty;
        public string OutputDescription { get; set; } = String.Empty;
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public byte Difficulty { get; set; }
        public bool IsPublic { get; set; }

        public long OwnerId { get; set; }

        public long? ContestId { get; set; }

        public static implicit operator ProblemSetPatchViewModel(ProblemSet problemSet)
        {
            return new ProblemSetPatchViewModel()
            {
                Name = problemSet.Name,
                Description = problemSet.Description,
                Type = problemSet.Type,
                InputDescription = problemSet.InputDescription,
                OutputDescription = problemSet.OutputDescription,
                TimeLimit = problemSet.TimeLimit,
                MemoryLimit = problemSet.MemoryLimit,
                Difficulty = problemSet.Difficulty,
                IsPublic = problemSet.IsPublic,
                OwnerId = problemSet.OwnerId,
                ContestId = problemSet.ContestId,
            };
        }
    }
}
