using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Application.ViewModels.Questions
{
    public class QuestionViewModel : QuestionBaseViewModel
    {
        public IEnumerable<string> Tags { get; set; } = default!;
        public string Description { get; set; } = String.Empty;
        

        public static implicit operator QuestionViewModel(Question question)
        {
            return new QuestionViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                Description = question.Description,
                ViewCount = question.ViewCount,
                Owner = question.Owner,
                CreatedAt = question.CreatedAt,
            };
        }
    }
}
