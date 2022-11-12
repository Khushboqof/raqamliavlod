using CodePower.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.ProblemSets;
using RaqamliAvlod.Domain.Entities.ProblemSets;

namespace RaqamliAvlod.DataAccess.Repositories.ProblemSets
{
    public class ProblemSetRepository : BaseRepository<ProblemSet>, IProblemSetRepository
    {
        public ProblemSetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ProblemSet?> FindByNameAsync(string problemSetName)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == problemSetName);
        }

        public override async Task<ProblemSet?> FindByIdAsync(long id)
        {
            return await _dbSet.Include(x => x.Owner).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<ProblemSetBaseViewModel>> GetAllViewAsync(PaginationParams @params, long userId)
        {
            var query = from problemSet in _dbcontext.ProblemSets.Where(x => x.IsPublic == true)
                                                                 .OrderBy(x=>x.Id)
                        select new ProblemSetBaseViewModel()
                        {
                            Id = problemSet.Id,
                            Name = problemSet.Name,
                            Type = problemSet.Type,
                        };
            return await PagedList<ProblemSetBaseViewModel>.ToPagedListAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<PagedList<ContestProblemSetBaseViewModel>> GetAllViewAsync(PaginationParams @params, long userId, long contestId)
        {
            var query = from problemSet in _dbcontext.ProblemSets.Where(x => x.ContestId == contestId)
                        .OrderBy(problemSet=>problemSet.ContestIdentifier)
                        select new ContestProblemSetBaseViewModel()
                        {
                            Id = problemSet.Id,
                            Name = problemSet.Name,
                            Type = problemSet.Type,
                            ContestCoins = problemSet.ContestCoins,
                            ContestIdentifier = problemSet.ContestIdentifier
                        };
            return await PagedList<ContestProblemSetBaseViewModel>.ToPagedListAsync(query, @params.PageNumber, @params.PageSize);
        }
    }
}
