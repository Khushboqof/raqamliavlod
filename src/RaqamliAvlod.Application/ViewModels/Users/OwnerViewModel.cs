using RaqamliAvlod.Domain.Entities.Users;

namespace RaqamliAvlod.Application.ViewModels.Users
{
    public class OwnerViewModel
    {
        public long UserId { get; set; }

        public string FullName { get; set; } = default!;

        public string ImagePath { get; set; } = default!;

        public string Username { get; set; } = default!;


        public static implicit operator OwnerViewModel(User user)
        {
            return new OwnerViewModel()
            {
                UserId = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                ImagePath = user.ImagePath,
                Username = user.Username!
            };
        }
    }
}