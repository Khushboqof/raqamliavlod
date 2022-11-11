using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.DataAccess.Interfaces.Questions
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        public Task<QuestionViewModel?> GetViewAsync(long questionId);

        public Task<PagedList<QuestionBaseViewModel>> GetAllViewAsync(PaginationParams @params);

        public Task CountViewAsync(long questionId);

        Task<PagedList<QuestionBaseViewModel>> SearchAsync(string search, PaginationParams @params);
    }
}
