using RaqamliAvlod.Domain.Entities.Users;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Common
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
