using CodePower.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Questions;
using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.DataAccess.Repositories.Questions
{
    public class QuestionAnswerRepository : BaseRepository<QuestionAnswer>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<QuestionAnswerViewModel>> GetAllByQuestionIdAsync(long questionId, PaginationParams @params)
        {
            var questionAsnwerViews = from questionAnswer in _dbSet.Where(answers => (answers.QuestionId == questionId) && (answers.HasReplied == false))
                                                            .Include(x => x.Owner).OrderByDescending(x => x.CreatedAt)
                                      select new QuestionAnswerViewModel(questionAnswer, _dbSet.Count(x => x.ParentId == questionAnswer.Id));
            
            return await PagedList<QuestionAnswerViewModel>.ToPagedListAsync(questionAsnwerViews, @params.PageNumber, @params.PageSize);

        }

        public async Task<IEnumerable<QuestionAnswerViewModel>> GetAllRepliesAsync(long answerId, PaginationParams @params)
        {
            var res = _dbSet.Where(x => x.ParentId == answerId).OrderBy(x => x.CreatedAt).Include(x => x.Owner).Select(x => (QuestionAnswerViewModel)x);
            return await PagedList<QuestionAnswerViewModel>.ToPagedListAsync(res, @params.PageNumber, @params.PageSize);
        }
          
    }
}
