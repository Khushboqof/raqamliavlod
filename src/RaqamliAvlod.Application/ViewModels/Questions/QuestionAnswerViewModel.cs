using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Application.ViewModels.Questions
{
    public class QuestionAnswerViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Username { get; set; } = string.Empty;
        public long QuestionId { get; set; }

        public static implicit operator QuestionAnswerViewModel(QuestionAnswer questionAnswer)
        {
            return new QuestionAnswerViewModel()
            {
                Id = questionAnswer.Id,
                Description = questionAnswer.Description,
                QuestionId = questionAnswer.QuestionId
            };
        }
    }
}
