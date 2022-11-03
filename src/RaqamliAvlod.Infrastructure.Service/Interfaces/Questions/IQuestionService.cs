using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions.Commands;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Domain.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;

public interface IQuestionService
{
    Task<bool> UpdateAsync(QuestionUpdateViewModel questionUpdateViewModel);
    Task<bool> DeleteAsync(Expression<Func<Question, bool>> expression);
}
