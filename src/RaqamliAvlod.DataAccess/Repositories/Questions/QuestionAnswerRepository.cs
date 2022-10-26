using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Questions;
using RaqamliAvlod.Domain.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.DataAccess.Repositories.Questions
{
    public class QuestionAnswerRepository : GenericRepository<QuestionAnswer>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
