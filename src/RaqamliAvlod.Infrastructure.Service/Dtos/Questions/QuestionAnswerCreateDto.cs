﻿using RaqamliAvlod.Domain.Entities.Questions;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos.Questions
{
    public class QuestionAnswerCreateDto
    {
        [Required]
        public string Description { get; set; } = String.Empty;
        public long? ParentId { get; set; }

        public static implicit operator QuestionAnswer(QuestionAnswerCreateDto questionAnswerCreateDto)
        {
            return new QuestionAnswer()
            {
                Description = questionAnswerCreateDto.Description,
                ParentId = questionAnswerCreateDto.ParentId
            };
        }
    }
}
