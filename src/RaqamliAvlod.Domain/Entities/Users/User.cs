using RaqamliAvlod.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Domain.Entities.Users
{
    public class User : Auditable
    {
        [MaxLength(50), MinLength(3)]
        public string FirstName { get; set; } = String.Empty;

        [MaxLength(50), MinLength(3)]
        public string LastName { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;

        [MaxLength(15)]
        public string PhoneNumber { get; set; } = String.Empty;

        [MaxLength(70)]
        public string Email { get; set; } = String.Empty;
        public bool EmailConfirmed { get; set; }

        [MaxLength(200)]
        public string PasswordHash { get; set; } = String.Empty;

        [MaxLength(100)]
        public string Salt { get; set; } = String.Empty;
        public DateTime UpdatedAt { get; set; }

    }
}
