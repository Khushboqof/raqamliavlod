using Microsoft.Extensions.Caching.Memory;
using RaqamliAvlod.Application.Exceptions;
using RaqamliAvlod.DataAccess.Interfaces.Users;
using RaqamliAvlod.Domain.Entities.Users;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Users;
using RaqamliAvlod.Infrastructure.Service.Security;
using System.Net;

namespace RaqamliAvlod.Infrastructure.Service.Services.Users
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repositroy;
        private readonly IAuthManager _authManager;
        private readonly IMemoryCache _cache;
        private readonly IEmailService _emailService;

        public AccountService(IUserRepository userRepository, IAuthManager authManager,
            IMemoryCache cache, IEmailService emailService)
        {
            _repositroy = userRepository;
            _authManager = authManager;
            _cache = cache;
            _emailService = emailService;
        }

        public async Task<string> LogInAsync(AccountLoginDto accountLogin)
        {
            var user = await _repositroy.GetByEmailAsync(accountLogin.Email);

            if (user is not null)
            {
                if (PasswordHasher.Verify(accountLogin.Password, user.Salt, user.PasswordHash))
                { 
                    return _authManager.GenerateToken(user);
                }
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "password is wrong");
            }
            throw new StatusCodeException(HttpStatusCode.NotFound, message: "email is wrong");

            if (user.EmailConfirmed is false)
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "email did not verified");
            }
        }

        public async Task<bool> RegisterAsync(AccountCreateDto accountCreate)
        {
            var user = await _repositroy.GetByEmailAsync(accountCreate.Email);

            if (user is null)
            {
                var user1 = (User)accountCreate;

                var hashResult = PasswordHasher.Hash(accountCreate.Password);
                user.Salt = hashResult.Salt;
                user.PasswordHash = hashResult.Hash;

                await _repositroy.CreateAsync(user1);

                var email = new SendToEmailDto()
                {
                    Email = accountCreate.Email
                };

                await SendCodeAsync(email);

                return true;
            }
            else
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "user already exist");
        }

        public async Task SendCodeAsync(SendToEmailDto sendToEmail)
        {
            int code = new Random().Next(1000, 99999);

            _cache.Set(sendToEmail.Email, code, TimeSpan.FromMinutes(10));

            var message = new EmailMessage()
            {
                To = sendToEmail.Email,
                Subject = "Verifcation code",
                Body = code.ToString()
            };

            await _emailService.SendAsync(message);
        }

        public async Task<bool> VerifyEmailAsync(VerifyEmailDto verifyEmail)
        {
            var user = await _repositroy.GetByEmailAsync(verifyEmail.Email);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            if (_cache.TryGetValue(verifyEmail.Email, out int expectedCode))
            {
                if (expectedCode != verifyEmail.Code)
                    throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is wrong");

                user.EmailConfirmed = true;

                await _repositroy.UpdateAsync(user.Id, user);

                return true;
            }
            else
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is expired");
        }

        public async Task<bool> VerifyPasswordAsync(UserResetPasswordDto userResetPassword)
        {
            var user = await _repositroy.GetByEmailAsync(userResetPassword.Email);

            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

            if (user.EmailConfirmed is false)
                throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Email did not verified");

            var changedPassword = PasswordHasher.Hash(userResetPassword.Password, user.Salt);

            user.PasswordHash = changedPassword;

            await _repositroy.UpdateAsync(user.Id, user);

            return true;
        }
    }
}
