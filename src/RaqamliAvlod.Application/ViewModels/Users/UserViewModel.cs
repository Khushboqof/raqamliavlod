﻿using RaqamliAvlod.Domain.Entities.Users;

namespace RaqamliAvlod.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int ContestCoins { get; set; }
        public int ProblemSetCoins { get; set; }

        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Username = user.Username,
                ImagePath = user.ImagePath,
                CreatedAt = user.CreatedAt.ToString(),
                ContestCoins = user.ContestCoins,
                ProblemSetCoins = user.ProblemSetCoins
            };
        }
    }
}
