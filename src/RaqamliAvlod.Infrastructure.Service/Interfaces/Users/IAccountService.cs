using RaqamliAvlod.Application.ViewModels.Accounts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Users
{
    public interface IAccountService
    {
        Task<string> LogInAsync(AccountLoginViewModel accountLogin);

        Task<bool> RegisterAsync(AccountCreateViewModel accountCreate);

        Task<bool> VerifyEmailAsync(VerifyEmailViewModel verifyEmail);

        Task SendCodeAsync(SendToEmailViewModel sendToEmail);

        Task<bool> VerifyPasswordAsync(UserResetPasswordViewModel userResetPassword);
    }
}