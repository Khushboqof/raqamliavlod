using CodePower.DataAccess.Common;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Contests;
using RaqamliAvlod.Domain.Entities.Contests;

namespace RaqamliAvlod.DataAccess.Repositories.Contests
{
    public class ContestSubmissionInfoRepository : BaseRepository<ContestSubmissionsInfo>,
        IContestSubmissionInfoRepository
    {
        public ContestSubmissionInfoRepository(AppDbContext context) : base(context)
        {
        }

        public Task<PagedList<ContestSubmissionsInfo>> GetAllByContestIdAsync(long contestId)
        {
            throw new NotImplementedException();
        }
    }
}