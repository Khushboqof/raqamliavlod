using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Infrastructure.Service.Dtos.Questions
{
    public class QuestionAnswerUpdateDto
    {
        public string Description { get; set; } = String.Empty;

        public static implicit operator QuestionAnswerUpdateDto(QuestionAnswer questionAnswer)
        {
            return new QuestionAnswerUpdateDto()
            {
                Description = questionAnswer.Description
            };
        }
    }
}
