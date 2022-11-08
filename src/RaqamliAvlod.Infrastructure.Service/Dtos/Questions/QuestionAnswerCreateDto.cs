using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Infrastructure.Service.Dtos.Questions
{
    public class QuestionAnswerCreateDto
    {
        public string Description { get; set; } = String.Empty;
        public long OwnerId { get; set; }
        public long QuestionId { get; set; }
        public long? ParentId { get; set; }

        public static implicit operator QuestionAnswer(QuestionAnswerCreateDto questionAnswerCreateDto)
        {
            return new QuestionAnswer()
            {
                Description = questionAnswerCreateDto.Description,
                OwnerId = questionAnswerCreateDto.OwnerId,
                QuestionId = questionAnswerCreateDto.QuestionId,
                ParentId = questionAnswerCreateDto.ParentId
            };
        }
    }
}
