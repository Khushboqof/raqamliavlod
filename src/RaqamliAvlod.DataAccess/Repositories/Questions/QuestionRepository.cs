using CodePower.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Questions;
using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.DataAccess.Repositories.Questions
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<Question?> FindByIdAsync(long id)
        {
            return await _dbcontext.Questions.Include(x => x.Owner)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<QuestionBaseViewModel>> GetAllViewAsync(PaginationParams @params)
        {
            var query = from question in _dbcontext.Questions.Include(x => x.Owner)
                        orderby question.CreatedAt descending
                        select (QuestionBaseViewModel)question;

            return await PagedList<QuestionBaseViewModel>.ToPagedListAsync(query,
                @params.PageNumber, @params.PageSize);
        }

        public async Task CountViewAsync(long questionId)
        {
            var question = await _dbcontext.Questions.FindAsync(questionId);
            if (question is not null)
            {
                question.ViewCount++;
                _dbcontext.Questions.Update(question);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<QuestionViewModel?> GetViewAsync(long questionId)
        {
            var query = (await _dbcontext.Questions.Include(x => x.Owner)
                    .FirstOrDefaultAsync(x => x.Id == questionId));
            if (query is null) return null;
            else
            {
                var questionView = (QuestionViewModel)query;
                questionView.Tags = from questiontag in _dbcontext.QuestionTags
                                    join tag in _dbcontext.Tags on questiontag.TagId equals tag.Id
                                    where questiontag.QuestionId == query.Id
                                    select tag.TagName;
                return questionView;
            }
        }
    }
}
