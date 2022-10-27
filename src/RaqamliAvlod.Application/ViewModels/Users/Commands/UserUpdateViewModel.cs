using Microsoft.AspNetCore.Http;

namespace RaqamliAvlod.Application.ViewModels.Users.Commands
{
    public class UserUpdateViewModel
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }


}
