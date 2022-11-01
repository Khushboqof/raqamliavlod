using RaqamliAvlod.Domain.Entities.Contests;

namespace RaqamliAvlod.Application.ViewModels.Contests.Queries
{
    public class ContestStandingsViewModel
    {
        public byte FixedProblems { get; set; }
        public int TotalSubmissions { get; set; }
        public int ErrorSubmissions { get; set; }

        public string Username { get; set; } = string.Empty;
        public string ContestName { get; set; } = string.Empty;
        public static implicit operator ContestStandingsViewModel(ContestStandings contest)
        {
            return new ContestStandingsViewModel()
            {
                FixedProblems = contest.FixedProblems,
                TotalSubmissions = contest.TotalSubmissions,
                ErrorSubmissions = contest.ErrorSubmissions,
            };
        }
    }
}
