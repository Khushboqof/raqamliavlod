using RaqamliAvlod.Domain.Entities.ProblemSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.ProblemSets
{
    public class ProblemSetTestViewModel
    {
        public long Id { get; set; }
        public string Input { get; set; } = String.Empty;
        public string Output { get; set; } = String.Empty;
        public static implicit operator ProblemSetTestViewModel(ProblemSetTest problemSetTest)
        {
            return new ProblemSetTestViewModel()
            {
                Id = problemSetTest.Id,
                Input = problemSetTest.Input,
                Output = problemSetTest.Output
            };
        }
    }
}
