using RaqamliAvlod.Domain.Entities.ProblemSets;

namespace RaqamliAvlod.DataAccess.Interfaces.ProblemSets
{
    public interface IProblemSetTestRepository
        : IRepository<ProblemSet>
    {
        public Task<IEnumerable<ProblemSetTest>> GetAllByProblemSetId(long problemSetId);
    }
}
