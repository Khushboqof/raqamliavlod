using RaqamliAvlod.Domain.Entities.Contests;

namespace RaqamliAvlod.Application.ViewModels.Contests.Commands
{
    public class ContestCreateViewModel
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPublic { get; set; }

        public static implicit operator Contest(ContestCreateViewModel contestCreateViewModel)
        {
            return new Contest()
            {
                Title = contestCreateViewModel.Title,
                Description = contestCreateViewModel.Description,
                StartDate = contestCreateViewModel.StartDate,
                EndDate = contestCreateViewModel.EndDate,
                IsPublic = contestCreateViewModel.IsPublic,
            };
        }
    }
}
