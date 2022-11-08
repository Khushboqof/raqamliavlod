using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Infrastructure.Service.Dtos.Questions
{
    public class TagCreateDto
    {
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
