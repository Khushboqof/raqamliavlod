using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.DataAccess.Interfaces.Questions
{
    public interface IQuestionAnswerRepository : IRepository<QuestionAnswer>
    {
        public Task<PagedList<QuestionAnswerViewModel>> GetAllByQuestionIdAsync(long questionId, PaginationParams @params);
        public Task<PagedList<QuestionAnswerViewModel>> GetAllRepliesAsync(long answerId, PaginationParams @params);
    }
}
