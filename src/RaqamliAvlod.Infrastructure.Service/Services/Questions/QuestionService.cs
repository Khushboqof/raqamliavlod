using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Questions;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITagService _tagService;
    private readonly IPaginatorService _paginator;

    public QuestionService(IUnitOfWork unitOfWork, IIdentityHelperService identityHelperService,
        IHttpContextAccessor httpContextAccessor, ITagService tagService,
        IPaginatorService paginator)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _tagService = tagService;
        _paginator = paginator;
    }

    public async Task<bool> CreateAsync(QuestionCreateDto dto, long userId)
    {
        var question = (Question)dto;
        var user = await _unitOfWork.Users.FindByIdAsync(userId);
        if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

        question.OwnerId = userId;
        question.CreatedAt = TimeHelper.GetCurrentDateTime();
        var result = await _unitOfWork.Questions.CreateAsync(question);

        List<string> tags = new();
        List<QuestionTag> questionTags = new();
        foreach (var tagdto in dto.Tags!)
        {
            var tag = await _unitOfWork.Tags.FindByNameAsync(tagdto);
            if (tag is null)
                tags.Add(tagdto);
            else questionTags.Add(new QuestionTag() { QuestionId = question.Id, TagId = tag.Id });
        }

        var createdTags = await _unitOfWork.Tags.AddRangeAsync(tags);
        foreach (var tag in createdTags)
            questionTags.Add(new QuestionTag() { QuestionId = question.Id, TagId = tag.Id });
        await _unitOfWork.QuestionTags.AddRangeAsync(questionTags);

        return result is not null;
    }

    public async Task<bool> DeleteAsync(long questionId)
    {
        if (await _unitOfWork.Questions.FindByIdAsync(questionId) is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");

        return await _unitOfWork.Questions.DeleteAsync(questionId) is not null;
    }

    public async Task<IEnumerable<QuestionBaseViewModel>> GetAllAsync(PaginationParams @params)
    {
        var questions = await _unitOfWork.Questions.GetAllViewAsync(@params);
        _paginator.ToPagenator(questions.MetaData);
        return questions;
    }

    public async Task<QuestionViewModel> GetAsync(long questionId)
    {
        var questionView = await _unitOfWork.Questions.GetViewAsync(questionId);

        if (questionView is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");

        await _unitOfWork.Questions.CountViewAsync(questionId);
        return questionView;
    }

    public async Task<bool> UpdateAsync(long questionId, QuestionCreateDto dto, long userId)
    {
        var question = _unitOfWork.Questions.FindByIdAsync(questionId);
        if (question is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Question Not Found!");

        var user = await _unitOfWork.Users.FindByIdAsync(userId);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");


        var editedQuestion = (Question)dto;
        editedQuestion.Id = question.Id;

        return await _unitOfWork.Questions.UpdateAsync(questionId, editedQuestion) is not null;
    }
}
