using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.Infrastructure.Service.Dtos;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Users
{
    public interface IUserService
    {
        Task<bool> UpdateAsync(long id, UserUpdateDto viewModel);
        Task<bool> DeleteAsync(long id);
        Task<UserViewModel> GetAsync(long id);
        Task<bool> ImageUpdateAsync(long id, IFormFile formFile);
        Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params);
    }
}
