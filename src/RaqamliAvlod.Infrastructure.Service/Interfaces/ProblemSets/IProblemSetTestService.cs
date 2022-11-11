using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.ProblemSets
{
    public interface IProblemSetTestService
    {
        public Task<IEnumerable<ProblemSetTestViewModel>> GetAllAsync(long problemSetId);

        public Task<bool> CreateAsync(ProblemSetTestCreateDto testCreateDto);

        public Task<bool> UpdateAsync(long problemSetTestId, ProblemSetTestCreateDto testCreateDto);

        public Task<bool> DeleteAsync(long problemSetTestId);

    }
}