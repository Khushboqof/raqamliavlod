using RaqamliAvlod.Domain.Entities.Questions;

namespace RaqamliAvlod.Application.ViewModels.Questions
{
    public class TagViewModel
    {
        public long Id { get; set; }
        public string TagName { get; set; } = String.Empty;

        public static implicit operator TagViewModel(Tag tag)
        {
            return new TagViewModel()
            {
                Id = tag.Id,
                TagName = tag.TagName
            };
        }
    }
}
