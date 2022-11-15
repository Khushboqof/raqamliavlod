using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Dtos;
namespace RaqamliAvlod.Infrastructure.Service.Interfaces.ProblemSets;

public interface IProblemSetTestService
{
    public Task<IEnumerable<ProblemSetTestViewModel>> GetAllAsync(long problemSetId);
    public Task<ProblemSetTestViewModel> GetAsync(long testId);
    public Task<bool> DeleteAsync(long testId);
    public Task<bool> CreateAsync(ProblemSetTestCreateDto testCreateDto);
    public Task<bool> UpdateAsync(long testId, ProblemSetTestCreateDto testCreateDto);
}
