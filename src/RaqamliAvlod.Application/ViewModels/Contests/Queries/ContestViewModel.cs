namespace RaqamliAvlod.Application.ViewModels.Contests.Queries
{
    public class ContestViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProblemSetCount { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPublic { get; set; }
    }
}
