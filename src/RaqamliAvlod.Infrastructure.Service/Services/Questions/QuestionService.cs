using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Questions;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Questions;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaginatorService _paginator;
    private readonly IQuestionTagService _questionTagService;

    public QuestionService(IUnitOfWork unitOfWork,
        IPaginatorService paginator, IQuestionTagService service)
    {
        _unitOfWork = unitOfWork;
        _paginator = paginator;
        _questionTagService = service;
    }

    public async Task<bool> CreateAsync(QuestionCreateDto dto, long userId)
    {
        var question = (Question)dto;
        var user = await _unitOfWork.Users.FindByIdAsync(userId);
        if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

        question.OwnerId = userId;
        question.CreatedAt = TimeHelper.GetCurrentDateTime();
        var result = await _unitOfWork.Questions.CreateAsync(question);

        await _questionTagService.CreateAsync(result, dto.Tags);
        return result is not null;
    }

    public async Task<bool> DeleteAsync(long questionId, long userId, UserRole userRole)
    {
        var res = await _unitOfWork.Questions.FindByIdAsync(questionId);
        if (res is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");
        if (res.OwnerId != userId && userRole == UserRole.User)
            throw new StatusCodeException(HttpStatusCode.Forbidden, "You cannot change it");

        return await _unitOfWork.Questions.DeleteAsync(questionId) is not null;
    }

    public async Task<IEnumerable<QuestionBaseViewModel>> GetAllAsync(PaginationParams @params)
    {
        var questions = await _unitOfWork.Questions.GetAllViewAsync(@params);
        _paginator.ToPagenator(questions.MetaData);
        return questions;
    }

    public async Task<QuestionViewModel> GetAsync(long questionId, long userId)
    {
        var questionView = await _unitOfWork.Questions.GetViewAsync(questionId);

        if (questionView is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");
        if (questionView.Owner.UserId == userId)
            questionView.CurrentUserIsAuthor = true;
        await _unitOfWork.Questions.CountViewAsync(questionId);
        return questionView;
    }

    public async Task<bool> UpdateAsync(long questionId, QuestionCreateDto dto, long userId)
    {
        var question = await _unitOfWork.Questions.FindByIdAsync(questionId);
        if (question is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");

        var user = await _unitOfWork.Users.FindByIdAsync(userId);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

        if (userId != question.OwnerId)
            throw new StatusCodeException(HttpStatusCode.Forbidden, "You cannot change it!");

        var editedQuestion = (Question)dto;
        editedQuestion.Id = question.Id;
        editedQuestion.OwnerId = userId;
        editedQuestion.CreatedAt = question.CreatedAt;
        await _questionTagService.UpdateAsync(editedQuestion, dto.Tags);

        return await _unitOfWork.Questions.UpdateAsync(questionId, editedQuestion) is not null;
    }
}
