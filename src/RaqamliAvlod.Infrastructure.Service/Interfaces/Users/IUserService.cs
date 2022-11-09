using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Dtos.Accounts;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Users
{
    public interface IUserService
    {
        Task<bool> UpdateAsync(long id, UserUpdateDto viewModel);
        Task<bool> DeleteAsync(long id);
        Task<UserViewModel> GetIdAsync(long id);
        Task<UserViewModel> GetUsernameAsync(string username);
        Task<bool> ImageUpdateAsync(long id, ImageUploadDto dto);
        Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params);
    }
}
