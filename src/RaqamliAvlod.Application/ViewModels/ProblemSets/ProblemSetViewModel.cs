using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.Domain.Entities.ProblemSets;

namespace RaqamliAvlod.Application.ViewModels.ProblemSets
{
    public class ProblemSetViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string InputDescription { get; set; } = String.Empty;
        public string OutputDescription { get; set; } = String.Empty;
        public string Note { get; set; } = String.Empty;
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public short Difficulty { get; set; }
        public OwnerViewModel Owner { get; set; } = default!;

        public static implicit operator ProblemSetViewModel(ProblemSet problemSet)
        {
            return new ProblemSetViewModel()
            {
                Id = problemSet.Id,
                Name = problemSet.Name,
                Description = problemSet.Description,
                Type = problemSet.Type,
                InputDescription = problemSet.InputDescription,
                OutputDescription = problemSet.OutputDescription,
                Note = problemSet.Note,
                TimeLimit = problemSet.TimeLimit,
                MemoryLimit = problemSet.MemoryLimit,
                Difficulty = problemSet.Difficulty,
                Owner = (OwnerViewModel) problemSet.Owner
            };
        }
    }
}
