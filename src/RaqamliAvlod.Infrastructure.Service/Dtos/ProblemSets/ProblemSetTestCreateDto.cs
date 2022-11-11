using RaqamliAvlod.Application.ViewModels.ProblemSets;
using RaqamliAvlod.Domain.Entities.ProblemSets;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos
{
    public class ProblemSetTestCreateDto
    {
        [Required]
        public string Input { get; set; } = String.Empty;

        [Required]
        public string Output { get; set; } = String.Empty;

        [Required]
        public long ProblemSetId { get; set; }

        public static implicit operator ProblemSetTest( ProblemSetTestCreateDto problemSetTest)
        {
            return new ProblemSetTest()
            {
                Input = problemSetTest.Input,
                Output = problemSetTest.Output,
                ProblemSetId = problemSetTest.ProblemSetId
            };
        }
    }
}