using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions
{
    public interface IQuestionAnswerService
    {
        Task<bool> CreateAsync(QuestionAnswerCreateDto dto, long userId);
        Task<bool> UpdateAsync(long id, QuestionAnswerUpdateDto dto, long userId);
        Task<bool> DeleteAsync(long id, long userId, UserRole role);
        Task<IEnumerable<QuestionAnswerViewModel>> GetAllAsync(long questionId, PaginationParams? @params = null);
    }
}
