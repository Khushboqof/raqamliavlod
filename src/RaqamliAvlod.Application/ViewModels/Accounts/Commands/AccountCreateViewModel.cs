using RaqamliAvlod.Domain.Entities.Users;

namespace RaqamliAvlod.Application.ViewModels.Accounts.Commands
{
    public class AccountCreateViewModel
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public static implicit operator User(AccountCreateViewModel accountCreateViewModel)
        {
            return new User()
            {
                FirstName = accountCreateViewModel.Firstname,
                LastName = accountCreateViewModel.Lastname,
                Username = accountCreateViewModel.Username,
                PhoneNumber = accountCreateViewModel.PhoneNumber,
                Email = accountCreateViewModel.Email,
            };
        }
    }
}
