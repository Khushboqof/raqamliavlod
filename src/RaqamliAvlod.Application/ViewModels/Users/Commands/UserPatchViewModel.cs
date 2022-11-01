using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Users.Commands
{
    public class UserPatchViewModel
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }

        public static implicit operator User(UserPatchViewModel user)
        {
            return new User()
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Username = user.Username,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
