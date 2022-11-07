using RaqamliAvlod.Application.ViewModels.Questions;
using RaqamliAvlod.Infrastructure.Service.Dtos.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Questions
{
    public interface ITagService
    {
        Task<bool> CreateAsync(string tagName);
        Task<bool> UpdateAsync(long id, TagCreateDto dto);
        Task<bool> DeleteAsync(long id);
        Task<TagViewModel> GetByIdAsync(long Id);
        Task<TagViewModel> GetByNameAsync(string name);
    }
}
