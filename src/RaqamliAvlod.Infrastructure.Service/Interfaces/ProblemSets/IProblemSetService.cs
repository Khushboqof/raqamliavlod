using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.Domain.Entities.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.ProblemSets
{
    public interface IProblemSetService
    {
        public Task<bool> CreateAsync(ProblemSetCreateDto createDto);

        public Task<ProblemSetViewModel> GetAsync(long problemSetId);  
    }
}