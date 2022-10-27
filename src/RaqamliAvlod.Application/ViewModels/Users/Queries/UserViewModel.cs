using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Application.ViewModels.Users.Queries
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public int ContestCoins { get; set; }
        public int ProblemSetCoins { get; set; }
    }
}
