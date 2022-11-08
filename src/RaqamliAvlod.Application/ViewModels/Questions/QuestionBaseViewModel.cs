using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Application.ViewModels.Questions
{
    public class QuestionBaseViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int ViewCount { get; set; }
        public OwnerViewModel Owner { get; set; } = null!;

        public static implicit operator QuestionBaseViewModel(Question question)
        {
            return new QuestionBaseViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                ViewCount = question.ViewCount,
                Owner = (OwnerViewModel) question.Owner
            };
        }
    }
}