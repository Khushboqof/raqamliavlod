using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Questions;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Questions
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionAnswerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(QuestionAnswerCreateDto dto, long userId)
        {
            var answers = (QuestionAnswer)dto;
            answers.OwnerId = userId;

            if (answers.ParentId is not null)
                answers.HasReplied = true;

            answers.CreatedAt = TimeHelper.GetCurrentDateTime();

            await _unitOfWork.QuestionAnswers.CreateAsync(answers);

            return true;
        }

        public async Task<bool> DeleteAsync(long id, long userId, UserRole role)
        {
            var answer = await _unitOfWork.QuestionAnswers.FindByIdAsync(id);
            if (answer is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "Answer not found");
            if (answer.OwnerId != userId && role == UserRole.User)
                throw new StatusCodeException(HttpStatusCode.Forbidden, "You can't delete it");
             await _unitOfWork.QuestionAnswers.DeleteAsync(id);
             answer.HasReplied = false;

             return true;
        }

        public async Task<IEnumerable<QuestionAnswerViewModel>> GetAllAsync(long questionId, long userId, PaginationParams? @params = null)
        {
            var questionAnswers = await _unitOfWork.QuestionAnswers.GetAllByQuestionIdAsync(questionId, @params);
            foreach (var answer in questionAnswers)
                if (answer.Owner.UserId == userId)
                    answer.CurrentUserIsAuthor = true;

            return questionAnswers;
        }

        public async Task<IEnumerable<QuestionAnswerViewModel>> GetRepliesAsync(long answerId, long userId)
        {
            if (await _unitOfWork.QuestionAnswers.FindByIdAsync(answerId) is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Answer not found!");
            var questionAnswers = await _unitOfWork.QuestionAnswers.GetAllRepliesAsync(answerId);
            foreach (var answer in questionAnswers)
                if (answer.Owner.UserId == userId)
                    answer.CurrentUserIsAuthor = true;
            return questionAnswers;
        }

        public async Task<bool> UpdateAsync(long id, QuestionAnswerUpdateDto dto, long userId)
        {
            var answer = await _unitOfWork.QuestionAnswers.FindByIdAsync(id);

            if (answer is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "Answer not found");
            if (answer.OwnerId != userId)
                throw new StatusCodeException(HttpStatusCode.Forbidden, "You can't change it");

            answer.Description = dto.Description;

            await _unitOfWork.QuestionAnswers.UpdateAsync(id, answer);

            return true;
        }
    }
}
