using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.ProblemSets;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.ProblemSets
{
    public class ProblemSetTestService : IProblemSetTestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaginatorService _paginator;

        public ProblemSetTestService(IUnitOfWork unitOfWork, IPaginatorService paginator)
        {
            this._unitOfWork = unitOfWork;
            this._paginator = paginator;
        }
        public async Task<bool> CreateAsync(ProblemSetTestCreateDto testCreateDto)
        {
            var problemSet = await _unitOfWork.ProblemSets.FindByIdAsync(testCreateDto.ProblemSetId);
            if (problemSet is null) throw new StatusCodeException(HttpStatusCode.NotFound, "ProblemSet is not found");

            var test = (ProblemSetTest) testCreateDto;

            await _unitOfWork.ProblemSetTests.CreateAsync(test);

            return true;
        }

        public async Task<bool> DeleteAsync(long testId)
        {
            var problemSetTest = await _unitOfWork.ProblemSetTests.FindByIdAsync(testId);
            if (problemSetTest is null) throw new StatusCodeException(HttpStatusCode.NotFound, "ProblemSet is not found");

            await _unitOfWork.ProblemSetTests.DeleteAsync(testId);

            return true;
        }

        public async Task<IEnumerable<ProblemSetTestViewModel>> GetAllAsync(long problemSetId)
        {
            var tests = await _unitOfWork.ProblemSetTests.GetAllByProblemSetId(problemSetId);

            var viewModels = new List<ProblemSetTestViewModel>();
            foreach (var test in tests)
            {
                viewModels.Add(test);
            }
            return viewModels;
        }

        public async Task<ProblemSetTestViewModel> GetAsync(long testId)
        {
            var problemSetTest = await _unitOfWork.ProblemSetTests.FindByIdAsync(testId);
            if (problemSetTest is null) throw new StatusCodeException(HttpStatusCode.NotFound, "ProblemSet is not found");

            return (ProblemSetTestViewModel)problemSetTest;
        }

        public async Task<bool> UpdateAsync(long testId, ProblemSetTestCreateDto testCreateDto)
        {
            var problemSetTest = await _unitOfWork.ProblemSetTests.FindByIdAsync(testId);
            if (problemSetTest is null) throw new StatusCodeException(HttpStatusCode.NotFound, "ProblemSet is not found");

            problemSetTest = testCreateDto;

            await _unitOfWork.ProblemSetTests.UpdateAsync(testId, problemSetTest);

            return true;
        }
    }
}
