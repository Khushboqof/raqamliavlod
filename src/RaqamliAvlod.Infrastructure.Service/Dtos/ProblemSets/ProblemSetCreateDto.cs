using RaqamliAvlod.Domain.Constants;
using RaqamliAvlod.Domain.Entities.ProblemSets;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos
{
    public class ProblemSetCreateDto
    {
        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Description { get; set; } = String.Empty;

        [Required]
        public string Type { get; set; } = String.Empty;

        public string? Note { get; set; } = String.Empty;

        [Required]
        public string InputDescription { get; set; } = String.Empty;

        [Required]
        public string OutputDescription { get; set; } = String.Empty;

        [Required, Range(0, EngineConstants.MAX_TIME_LIMIT)]
        public int TimeLimit { get; set; }

        [Required, Range(0, EngineConstants.MAX_MEMORY_LIMIT)]
        public int MemoryLimit { get; set; }

        [Required, Range(0, EngineConstants.MAX_DIFFICULTY)]
        public short Difficulty { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public long OwnerId { get; set; }

        public static implicit operator ProblemSet(ProblemSetCreateDto problemSetCreateDto)
        {
            return new ProblemSet()
            {
                Name = problemSetCreateDto.Name,
                Description = problemSetCreateDto.Description,
                Type = problemSetCreateDto.Type,
                Note = problemSetCreateDto.Note,
                InputDescription = problemSetCreateDto.InputDescription,
                OutputDescription = problemSetCreateDto.OutputDescription,
                TimeLimit = problemSetCreateDto.TimeLimit,
                MemoryLimit = problemSetCreateDto.MemoryLimit,
                Difficulty = problemSetCreateDto.Difficulty,
                IsPublic = problemSetCreateDto.IsPublic,
                OwnerId = problemSetCreateDto.OwnerId,
                CreatedAt = TimeHelper.GetCurrentDateTime()
            };
        }
    }
}
