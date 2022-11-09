using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions
{
    public interface ITagService
    {
        Task<bool> CreateAsync(TagCreateDto tagCreateDto);
        Task<bool> UpdateAsync(long id, TagCreateDto dto);
        Task<bool> DeleteAsync(long id);
        Task<TagViewModel> GetByIdAsync(long Id);
        Task<IEnumerable<TagViewModel>> GetByNameAsync(string name);
    }
}
