using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Application.ViewModels.Questions.Commands
{
    public class QuestionCreateViewModel
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string[]? Tags { get; set; }

        public static implicit operator Question(QuestionCreateViewModel questionCreateViewModel)
        {
            return new Question()
            {
                Title = questionCreateViewModel.Title,
                Description = questionCreateViewModel.Description,
                Tags = questionCreateViewModel.Tags
            };
        }
    }
}
