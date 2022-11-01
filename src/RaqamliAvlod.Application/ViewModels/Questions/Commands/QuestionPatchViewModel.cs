using RaqamliAvlod.Domain.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Questions.Commands
{
    public class QuestionPatchViewModel
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string[]? Tags { get; set; }

        public static implicit operator QuestionPatchViewModel(Question question)
        {
            return new QuestionPatchViewModel()
            {
                Title = question.Title,
                Description = question.Description,
                Tags = question.Tags,
            };
        }
    }
}
