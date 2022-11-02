using CodePower.DataAccess.Common;
using RaqamliAvlod.Domain.Entities.Questions;
using System;

namespace RaqamliAvlod.DataAccess.Interfaces.Questions
{
    public interface IQuestionTagRepository : IRepository<QuestionTag>
    {
        public Task<PagedList<QuestionTag>> GetAllTagsFromQuestionAsync(long questionId);
    }
}