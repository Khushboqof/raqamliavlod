using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.ProblemSets
{
    public interface IProblemSetService
    {
        public Task<IEnumerable<ProblemSetBaseViewModel>> GetAllAsync(PaginationParams @params, long? userId);
        
        public Task<ProblemSetViewModel> GetAsync(long problemSetId);  

        public Task<bool> CreateAsync(ProblemSetCreateDto createDto);

        public Task<bool> UpdateAsync(long problemSetId, ProblemSetCreateDto updateDto);

        public Task<bool> DeleteAsync(long problemSetId);
    }
}