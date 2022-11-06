using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.DataAccess.Interfaces.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Questions;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Questions;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;

    }
    public async Task<bool> CreateAsync(long questionId, QuestionCreateDto dto)
    {
        QuestionViewModel question = await _questionRepository.CreateAsync(dto);

        return true;
    }

    public async Task<bool> DeleteAsync(long questionId)
    {
        QuestionViewModel question = await _questionRepository.FindByIdAsync(questionId);

        if (question == null)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest, message:"Question Not Found!");
        }
        else
        {
            await _questionRepository.DeleteAsync(questionId);
        }
    }

    public Task<IEnumerable<QuestionViewModel>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<QuestionViewModel> GetAsync(long questionId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long questionId, QuestionCreateDto dto)
    {
        throw new NotImplementedException();
    }
}
