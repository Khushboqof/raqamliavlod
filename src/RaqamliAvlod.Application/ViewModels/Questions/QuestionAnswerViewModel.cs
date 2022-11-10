using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Application.ViewModels.Questions
{
    public class QuestionAnswerViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public int ReplyCount { get; set; } = 0;
        public bool HasReplied { get; set; }
        public long? ParentId { get; set; }
        public OwnerViewModel Owner { get; set; }
        public long QuestionId { get; set; }

        public static implicit operator QuestionAnswerViewModel(QuestionAnswer questionAnswer)
        {
            return new QuestionAnswerViewModel()
            {
                Id = questionAnswer.Id,
                Description = questionAnswer.Description,
                HasReplied = questionAnswer.HasReplied,
                Owner = (OwnerViewModel)questionAnswer.Owner,
                QuestionId = questionAnswer.QuestionId,
                ParentId = questionAnswer.ParentId
            };
        }
        public QuestionAnswerViewModel(QuestionAnswer questionAnswer, int replyCount)
        {
            Id = questionAnswer.Id;
            Description = questionAnswer.Description;
            HasReplied = questionAnswer.HasReplied;
            Owner = (OwnerViewModel)questionAnswer.Owner;
            QuestionId = questionAnswer.QuestionId;
            ParentId = questionAnswer.ParentId; 
            ReplyCount = replyCount;
        }
        public QuestionAnswerViewModel()
        {
        }
    }
}
