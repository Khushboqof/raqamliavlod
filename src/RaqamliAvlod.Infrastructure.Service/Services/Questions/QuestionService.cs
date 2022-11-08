using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;
using RaqamliAvlod.Infrastructure.Service.Managers;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Questions;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIdentityHelperService _identityHelperService;

    public QuestionService(IUnitOfWork unitOfWork, IIdentityHelperService identityHelperService)
    {
        _unitOfWork = unitOfWork;
        _identityHelperService = identityHelperService;
    }

    public async Task<bool> CreateAsync(QuestionCreateDto dto)
    {
        var question = (Question)dto;   

        question.OwnerId = _identityHelperService.GetUserId();

        var result = await _unitOfWork.Questions.CreateAsync(question);

        return result is not null;
    }

    public async Task<bool> DeleteAsync(long questionId)
    {
        var question = await _unitOfWork.Questions.FindByIdAsync(questionId);

        if (question is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");
        }

        var result = await _unitOfWork.Questions.DeleteAsync(questionId);

        return result is not null;
    }

    public async Task<IEnumerable<QuestionViewModel>> GetAllAsync(PaginationParams @params)
    {
        var questions = await _unitOfWork.Questions.GetAllAsync(@params);

        var questionViewModels = new List<QuestionViewModel>();

        foreach (var question in questions)
        {
            var owner = (await _unitOfWork.Users.FindByIdAsync(question.OwnerId))!;
            var ownerViewModel = (OwnerViewModel)owner;

            var questionViewModel = (QuestionViewModel)question;
            questionViewModel.Owner = ownerViewModel;

            questionViewModels.Add(questionViewModel);
        }

        return questionViewModels;
    }

    public async Task<QuestionViewModel> GetAsync(long questionId)
    {
        var question = await _unitOfWork.Questions.FindByIdAsync(questionId);

        if (question is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");
        }

        question.ViewCount++;

        var questionViewModel = (QuestionViewModel) await _unitOfWork.Questions.UpdateAsync(questionId, question);
        questionViewModel.Owner = (OwnerViewModel) await _unitOfWork.Users.FindByIdAsync(question.OwnerId);
        return questionViewModel;
    }

    public async Task<bool> UpdateAsync(long questionId, QuestionCreateDto dto)
    {
        var question = _unitOfWork.Questions.FindByIdAsync(questionId);

        if (question is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");
        }

        var editedQuestion = (Question)dto;
        editedQuestion.Id = question.Id;

        return await _unitOfWork.Questions.UpdateAsync(questionId, editedQuestion) is not null;
    }
}
