using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.ProblemSets;
using RaqamliAvlod.Domain.Entities.ProblemSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.DataAccess.Repositories.ProblemSets
{
    public class ProblemSetRepository : GenericRepository<ProblemSet>, IProblemSetRepository
    {
        public ProblemSetRepository(AppDbContext context) : base(context)
        {
        }
    }
}
