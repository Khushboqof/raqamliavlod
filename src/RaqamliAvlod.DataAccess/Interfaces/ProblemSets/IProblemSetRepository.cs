using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.Domain.Entities.ProblemSets;

namespace RaqamliAvlod.DataAccess.Interfaces.ProblemSets
{
    public interface IProblemSetRepository : IRepository<ProblemSet>
    {
        public Task<ProblemSet?> FindByNameAsync(string problemSetName);

        public Task<PagedList<ProblemSetBaseViewModel>> GetAllViewAsync(PaginationParams @params, long userId);
    }
}
