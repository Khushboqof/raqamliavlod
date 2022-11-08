using RaqamliAvlod.Infrastructure.Service.Dtos;

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