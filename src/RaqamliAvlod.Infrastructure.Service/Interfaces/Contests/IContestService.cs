using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Contests;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Contests
{
    public interface IContestService
    {
        public Task<bool> CreateAsync(ContestCreateDto contestCreateDto);

        public Task<ContestViewModel> GetAsync(long contestId); 

        public Task<IEnumerable<ContestViewModel>> GetAllAsync(PaginationParams @params);

        public Task<bool> DeleteAsync(long contestId);

        public Task<bool> UpdateAsync(long courseId, ContestCreateDto createDto);

    }
}
