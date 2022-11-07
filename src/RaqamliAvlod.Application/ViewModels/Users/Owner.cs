using RaqamliAvlod.Domain.Entities.Users;

namespace RaqamliAvlod.Application.ViewModels.Users
{
    public class Owner
    {
        public long UserId { get; set; }

        public string FullName { get; set; } = default!;

        public string ImagePath { get; set; } = default!;


        public static implicit operator Owner(User user)
        {
            return new Owner()
            {
                UserId = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                ImagePath = user.ImagePath
            };
        }
    }
}