using RaqamliAvlod.Domain.Entities.ProblemSets;

namespace RaqamliAvlod.Application.ViewModels.ProblemSets.Commands
{
    public class ProblemSetCreateViewModel
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

        public static implicit operator ProblemSet(ProblemSetCreateViewModel problemSetCreateViewModel)
        {
            return new ProblemSet()
            {
                Name = problemSetCreateViewModel.Name,
                Description = problemSetCreateViewModel.Description,
                Type = problemSetCreateViewModel.Type,
                InputDescription = problemSetCreateViewModel.InputDescription,
                OutputDescription = problemSetCreateViewModel.OutputDescription,
                TimeLimit = problemSetCreateViewModel.TimeLimit,
                MemoryLimit = problemSetCreateViewModel.MemoryLimit,
                Difficulty = problemSetCreateViewModel.Difficulty,
                IsPublic = problemSetCreateViewModel.IsPublic,
                OwnerId = problemSetCreateViewModel.OwnerId,
                ContestId = problemSetCreateViewModel.ContestId
            };
        }
    }
}
