using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Users;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Users;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public UserService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _unitOfWork.Users.FindByIdAsync(id);

            if (result is null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "User don't exist");

            var user = await _unitOfWork.Users.DeleteAsync(id);

            return user != null;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params)
        {
            var users = await _unitOfWork.Users.GetAllAsync(@params);

            var userViews = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userView = (UserViewModel)user;

                userViews.Add(userView);
            }

            return userViews;
        }

        public async Task<UserViewModel> GetAsync(long id)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(id);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            var userView = (UserViewModel)user;

            return userView;
        }

        public async Task<bool> ImageUpdateAsync(long id, IFormFile formFile)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(id);

            if (user.ImagePath is not null)
            {
                await _fileService.DeleteImageAsync(user.ImagePath);

                user.ImagePath = await _fileService.SaveImageAsync(formFile);
            }
            await _unitOfWork.Users.UpdateAsync(id, user);

            return true;
        }

        public async Task<bool> UpdateAsync(long id, UserUpdateDto viewModel)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(id);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            var newUser = (User)viewModel;
            newUser.Id = id;
            newUser.UpdatedAt = TimeHelper.GetCurrentDateTime();
            newUser.ImagePath = user.ImagePath;

            await _unitOfWork.Users.UpdateAsync(id, newUser);

            return true;
        }
    }
}
