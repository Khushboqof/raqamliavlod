using RaqamliAvlod.Domain.Entities.ProblemSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.ProblemSets.Commands
{
    public class ProblemSetUpdateViewModel
    {
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        [Required]
        public string InputDescription { get; set; } = String.Empty;
        [Required]
        public string OutputDescription { get; set; } = String.Empty;
        public int TimeLimit { get; set; }
        [Required]
        public int MemoryLimit { get; set; }
        [Required]
        public byte Difficulty { get; set; }
        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public long OwnerId { get; set; }

        public long? ContestId { get; set; }

        public static implicit operator ProblemSetUpdateViewModel(ProblemSet problemSet)
        {
            return new ProblemSetUpdateViewModel()
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
