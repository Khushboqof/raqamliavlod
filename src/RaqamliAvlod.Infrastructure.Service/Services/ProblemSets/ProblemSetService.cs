using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.ProblemSets;
using System;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.ProblemSets
{
    public class ProblemSetService : IProblemSetService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProblemSetService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(ProblemSetCreateDto createDto)
        {
            var oldProblemSet = await _unitOfWork.ProblemSets.FindByNameAsync(createDto.Name);
            if (oldProblemSet is not null) throw new StatusCodeException(HttpStatusCode.BadRequest, $"There is alredy exist problemset named by {createDto.Name}");

            var ownerUser = await _unitOfWork.Users.FindByIdAsync(createDto.OwnerId);
            if (ownerUser is null) throw new StatusCodeException(HttpStatusCode.NotFound, $"Owner is not known. Owner id = {createDto.OwnerId} is not valid");

            var problemSet = (ProblemSet)createDto;
            problemSet.ContestIdentifier = 'A';
            await _unitOfWork.ProblemSets.CreateAsync(problemSet);
            return true;
        }

        public async Task<ProblemSetViewModel> GetAsync(long problemSetId)
        {
            var problemSet = await _unitOfWork.ProblemSets.FindByIdAsync(problemSetId);
            if (problemSet is null) throw new StatusCodeException(HttpStatusCode.NotFound, "ProblemSet is not found");

            return (ProblemSetViewModel) problemSet;
        }
    }
}