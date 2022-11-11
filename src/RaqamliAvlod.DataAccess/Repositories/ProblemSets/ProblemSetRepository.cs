using CodePower.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.ProblemSets;
using RaqamliAvlod.Domain.Entities.ProblemSets;

namespace RaqamliAvlod.DataAccess.Repositories.ProblemSets
{
    public class ProblemSetRepository : GenericRepository<ProblemSet>, IProblemSetRepository
    {
        public ProblemSetRepository(AppDbContext context) : base(context)
        {
        }
        #region Public and Private
        public async Task<ProblemSet?> FindByNameAsync(string problemSetName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == problemSetName);
        }
        #endregion

        #region Public
        public override async Task<ProblemSet?> FindByIdAsync(long id)
        {
            return await _dbSet.Include(x => x.Owner).FirstOrDefaultAsync(x => x.Id == id && x.IsPublic == true);
        }

        public async Task<PagedList<ProblemSetBaseViewModel>> GetAllViewAsync(PaginationParams @params, long userId)
        {
            var query = from problemSet in _dbcontext.ProblemSets.Where(x => x.IsPublic == true)
                        select new ProblemSetBaseViewModel()
                        {
                            Id = problemSet.Id,
                            Name = problemSet.Name,
                            Type = problemSet.Type,
                        };
            return await PagedList<ProblemSetBaseViewModel>.ToPagedListAsync(query, @params.PageNumber, @params.PageSize);
        }
        #endregion


        #region Private
        #endregion
    }
}
