using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Courses;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Domain.Entities.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using System.Linq.Expressions;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;

public interface IQuestionService
{
    Task<bool> CreateAsync(QuestionCreateDto dto);
    Task<bool> UpdateAsync(long questionId, QuestionCreateDto dto);
    Task<bool> DeleteAsync(long questionId);
    Task<QuestionViewModel> GetAsync(long questionId);
    Task<IEnumerable<QuestionViewModel>> GetAllAsync(PaginationParams @params);
}
