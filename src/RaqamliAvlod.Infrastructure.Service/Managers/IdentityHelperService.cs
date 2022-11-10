using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Domain.Enums;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;

namespace RaqamliAvlod.Infrastructure.Service.Managers
{
    public class IdentityHelperService : IIdentityHelperService
    {
        private readonly IHttpContextAccessor _accessor;

        public IdentityHelperService(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }

        public string GetUserEmail()
        {
            return _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")!.Value;
        }

        public long? GetUserId()
        {
            var res = _accessor.HttpContext!.User.FindFirst("Id")!.Value;
            if (long.TryParse(res, out long id))
                return id;
            return null;
        }

        public string GetUserName()
        {
            return _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")!.Value;
        }

        public UserRole? GetUserRole()
        {
            var res = _accessor.HttpContext!.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")!.Value;
            if (Enum.TryParse<UserRole>(res, out UserRole role))
                return role;
            return null;
        }
    }
}
