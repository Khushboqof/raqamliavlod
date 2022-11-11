using RaqamliAvlod.Domain.Entities.Contests;

namespace RaqamliAvlod.DataAccess.Interfaces.Contests
{
    public interface IContestRepository : IGenericRepository<Contest>
    {
        public Task<Contest?> GetByTitleAsync(string title);
    }
}
