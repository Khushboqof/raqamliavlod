namespace RaqamliAvlod.Application.ViewModels.ProblemSets
{
    public class ProblemSetBaseViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Type { get; set; } = String.Empty;

        public bool CurrentUserIsSolved { get; set; }

        public int TotalSubmissions { get; set; }

        public int CorrectSubmissions { get; set; }

        public int TotalParticipants { get; set; }

        public int Percentage { get; set; }
    }
}