using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.ProblemSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Services.ProblemSets
{
    public class ProblemSetTestSevice : IProblemSetTestService
    {
        public Task<bool> DeleteAsync(long testId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProblemSetTestViewModel>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<ProblemSetTestViewModel> GetAsync(long testId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProblemSetTestCreateDto testCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long testId, ProblemSetTestCreateDto testCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
