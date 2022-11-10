using RaqamliAvlod.Attributes;
using RaqamliAvlod.Domain.Entities.Questions;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos.Questions
{
    public class TagCreateDto
    {
        [Required, Name]
        public string TagName { get; set; } = String.Empty;


        public static implicit operator Tag(TagCreateDto tagCreateDto)
        {
            return new Tag()
            {
                TagName = tagCreateDto.TagName.ToLower()
            };
        }
    }
}
