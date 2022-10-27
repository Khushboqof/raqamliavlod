using CodePower.DataAccess.Common;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Submissions;
using RaqamliAvlod.Domain.Entities.Submissions;


namespace RaqamliAvlod.DataAccess.Repositories.Submissions
{
    public class SubmissionRepository : GenericRepository<Submission>
    {
        public SubmissionRepository(AppDbContext context) : base(context)
        {

        }
    }
}
