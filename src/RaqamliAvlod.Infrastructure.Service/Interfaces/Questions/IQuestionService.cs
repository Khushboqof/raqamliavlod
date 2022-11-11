using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;

public interface IQuestionService
{
    Task<bool> CreateAsync(QuestionCreateDto dto, long userId);
    Task<bool> UpdateAsync(long questionId, QuestionCreateDto dto, long userId);
    Task<bool> DeleteAsync(long questionId, long userId, UserRole userRole);
    Task<QuestionViewModel> GetAsync(long questionId, long? userId);
    Task<IEnumerable<QuestionBaseViewModel>> GetAllAsync(PaginationParams @params);
    Task<IEnumerable<QuestionBaseViewModel>> SearchAsync(string search, PaginationParams @params);
}
