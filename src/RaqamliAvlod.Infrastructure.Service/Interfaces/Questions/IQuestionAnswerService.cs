using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions
{
    public interface IQuestionAnswerService
    {
        Task<bool> CreateAsync(long questionId, QuestionAnswerCreateDto dto, long userId);
        Task<bool> UpdateAsync(long id, QuestionAnswerUpdateDto dto, long userId);
        Task<bool> DeleteAsync(long id, long userId, UserRole role);
        Task<IEnumerable<QuestionAnswerViewModel>> GetAllAsync(long questionId, long? userId, PaginationParams? @params = null);
        Task<IEnumerable<QuestionAnswerViewModel>> GetRepliesAsync(long answerId, long? userId);
    }
}
