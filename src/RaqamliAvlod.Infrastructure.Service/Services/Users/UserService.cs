using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Application.ViewModels.Users;
using RaqamliAvlod.DataAccess.Interfaces;
using RaqamliAvlod.Domain.Entities.Users;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Dtos.Accounts;
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
        private readonly IPaginatorService _paginatorService;

        public UserService(IUnitOfWork unitOfWork, IFileService fileService, IPaginatorService paginatorService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _paginatorService = paginatorService;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _unitOfWork.Users.FindByIdAsync(id);

            if (result is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User don't exist");

            var user = await _unitOfWork.Users.DeleteAsync(id);

            return user != null;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params)
        {
            var users = await _unitOfWork.Users.GetAllAsync(@params);
            _paginatorService.ToPagenator(users.MetaData);

            var userViews = new List<UserViewModel>();

            foreach (var user in users)
            {               
                 var userView = (UserViewModel)user;

                 userViews.Add(userView);                
            }

            return userViews;
        }

        public async Task<UserViewModel> GetUsernameAsync(string username)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(username.Trim());

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            var userView = (UserViewModel)user;

            return userView;
        }

        public async Task<UserViewModel> GetIdAsync(long id)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(id);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            var userView = (UserViewModel)user;

            return userView;
        }

        public async Task<bool> ImageUpdateAsync(long id, ImageUploadDto dto)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(id);

            if (user!.ImagePath is not null)
            {
                await _fileService.DeleteImageAsync(user.ImagePath);

                user.ImagePath = await _fileService.SaveImageAsync(dto.Image);
            }
            await _unitOfWork.Users.UpdateAsync(id, user);

            return true;
        }

        public async Task<bool> UpdateAsync(long id, UserUpdateDto viewModel)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(id);
            var userName = await _unitOfWork.Users.GetByUsernameAsync(viewModel.Username);
            var phoneNumber = await _unitOfWork.Users.GetByPhonNumberAsync(viewModel.PhoneNumber);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            if (userName is not null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "This username already exist");

            if (phoneNumber is not null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "This phoneNumber already exist");

            viewModel.Firstname.Trim();
            viewModel.Lastname.Trim();
            viewModel.Username.Trim();

            var newUser = (User)viewModel;
            newUser.Id = id;
            newUser.UpdatedAt = TimeHelper.GetCurrentDateTime();
            newUser.ImagePath = user.ImagePath;
            newUser.PasswordHash = user.PasswordHash;
            newUser.Salt = user.Salt;
            newUser.Email = user.Email;
            newUser.ContestCoins = user.ContestCoins;
            newUser.Role = user.Role;
            newUser.ProblemSetCoins = user.ProblemSetCoins;
            newUser.EmailConfirmed = user.EmailConfirmed;
            newUser.CreatedAt = user.CreatedAt;

            await _unitOfWork.Users.UpdateAsync(id, newUser);

            return true;
        }

        public async Task<bool> RoleControlAsync(long userId, ushort roleNum)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(userId);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            if (roleNum >= 2)
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "This role don't exist");

            user.Role = (UserRole)roleNum;
            await _unitOfWork.Users.UpdateAsync(userId, user);

            return true;
        }
    }
}
