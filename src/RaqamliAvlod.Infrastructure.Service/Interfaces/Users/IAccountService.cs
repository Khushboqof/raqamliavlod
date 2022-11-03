using RaqamliAvlod.Application.ViewModels.Accounts.Commands;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Users
{
    public interface IAccountService
    {
        Task<string> LogInAsync(AccountLoginDto accountLogin);

        Task<bool> RegisterAsync(AccountCreateDto accountCreate);

        Task<bool> VerifyEmailAsync(VerifyEmailDto verifyEmail);

        Task SendCodeAsync(SendToEmailDto sendToEmail);

        Task<bool> VerifyPasswordAsync(UserResetPasswordDto userResetPassword);
    }
}