using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Attributes;
using RaqamliAvlod.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos
{
    public class UserUpdateDto
    {
        [Required, Name]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        public string Lastname { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public static implicit operator User(UserUpdateDto userUpdate)
        {
            return new User()
            {
                FirstName = userUpdate.Firstname,
                LastName = userUpdate.Lastname,
                Username = userUpdate.Username,
                PhoneNumber = userUpdate.PhoneNumber,
            };
        }
    }


}
