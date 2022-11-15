using CodePower.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Users;
using RaqamliAvlod.Domain.Entities.Users;

namespace RaqamliAvlod.DataAccess.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<User?> GetByEmailAsync(string email)
            => await _dbcontext.Users.FirstOrDefaultAsync(user => user.Email == email);

        public async Task<User?> GetByUsernameAsync(string username)
            => await _dbcontext.Users.FirstOrDefaultAsync(user => user.Username == username);

        public async Task<User?> GetByPhonNumberAsync(string phoneNumber)
            => await _dbcontext.Users.FirstOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
        public override async Task<PagedList<User>> GetAllAsync(PaginationParams @params)
            => (await PagedList<User>.ToPagedListAsync(_dbSet.Where(p => p.EmailConfirmed.Equals(true))
                .OrderBy(user => user.Id), @params.PageNumber, @params.PageSize));
    }
}
