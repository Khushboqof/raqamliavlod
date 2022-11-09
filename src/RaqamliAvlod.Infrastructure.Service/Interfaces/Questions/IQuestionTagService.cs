using RaqamliAvlod.Domain.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions
{
    public interface IQuestionTagService
    {
        Task<bool> CreateAsync(Question question, IEnumerable<string> tags);
        Task<bool> UpdateAsync(Question question, IEnumerable<string> tags);
    }
}
