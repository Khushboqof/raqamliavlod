using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.ProblemSets;
using RaqamliAvlod.Domain.Entities.ProblemSets;

namespace RaqamliAvlod.DataAccess.Repositories.ProblemSets
{
    public class ProblemSetTestRepository : BaseRepository<ProblemSetTest>, IProblemSetTestRepository
    {
        public ProblemSetTestRepository(AppDbContext context) : base(context)
        {

        }

        public Task<IEnumerable<ProblemSetTest>> GetAllByProblemSetId(long problemSetId)
        {
            throw new NotImplementedException();
        }
    }
}
