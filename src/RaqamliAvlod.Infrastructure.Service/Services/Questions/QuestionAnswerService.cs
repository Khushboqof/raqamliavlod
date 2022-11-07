using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Questions;
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
        public async Task<bool> CreateAsync(QuestionAnswerCreateDto dto)
        {
            var answers = (QuestionAnswer)dto;

            if (answers.ParentId is not null)
                answers.HasReplied = true;

            answers.CreatedAt = TimeHelper.GetCurrentDateTime();

            await _unitOfWork.QuestionAnswers.CreateAsync(answers);

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var answer = await _unitOfWork.QuestionAnswers.FindByIdAsync(id);
            if (answer is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "Answer not found");
            else
            {
                await _unitOfWork.QuestionAnswers.DeleteAsync(id);
                answer.HasReplied = false;

                return true;
            }
        }

        public async Task<IEnumerable<QuestionAnswerViewModel>> GetAllAsync(long questionId, PaginationParams? @params = null)
        {
            var questionAnswers = await _unitOfWork.QuestionAnswers.GetAllByQuestionIdAsync(questionId, @params);

            var questionAnswerViews = new List<QuestionAnswerViewModel>();

            foreach (var answer in questionAnswers)
            {
                var questionOwner = await _unitOfWork.Users.FindByIdAsync(answer.OwnerId);

                var questionAnswerView = (QuestionAnswerViewModel)answer;

                questionAnswerView.Username = questionOwner.Username;

                questionAnswerViews.Add(questionAnswerView);
            }

            return questionAnswerViews;
        }

        public async Task<bool> UpdateAsync(long id, QuestionAnswerUpdateDto dto)
        {
            var answer = await _unitOfWork.QuestionAnswers.FindByIdAsync(id);

            if (answer is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "Answer not found");

            answer.Description = dto.Description;

            await _unitOfWork.QuestionAnswers.UpdateAsync(id, answer);

            return true;
        }
    }
}
