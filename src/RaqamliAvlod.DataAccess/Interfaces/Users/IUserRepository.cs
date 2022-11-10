using RaqamliAvlod.Domain.Entities.Users;

namespace RaqamliAvlod.DataAccess.Interfaces.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User?> GetByEmailAsync(string email);

        public Task<User?> GetByUsernameAsync(string username);

        public Task<User?> GetByPhonNumberAsync(string phoneNumber);
    }
}
