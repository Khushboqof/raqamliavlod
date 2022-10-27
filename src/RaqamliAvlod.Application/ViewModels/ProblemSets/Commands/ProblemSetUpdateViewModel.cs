namespace RaqamliAvlod.Application.ViewModels.ProblemSets.Commands
{
    public class ProblemSetUpdateViewModel
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
    }
}
