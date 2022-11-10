using RaqamliAvlod.Domain.Enums;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Common
{
    public interface IIdentityHelperService
    {
        UserRole GetUserRole();
        long GetUserId();
        string GetUserName();
        string GetUserEmail();
    }
}
