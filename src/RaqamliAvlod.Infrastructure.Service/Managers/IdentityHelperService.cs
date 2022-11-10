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
            var res = _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            return res is not null ? res.Value : string.Empty;
        }

        public long? GetUserId()
        {
            var res = _accessor.HttpContext!.User.FindFirst("Id");
            return res is not null ? long.Parse(res.Value) : null; 
        }

        public string GetUserName()
        {
            var res = _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            return res is not null ? res.Value : string.Empty;
        }

        public UserRole? GetUserRole()
        {
            var res = _accessor.HttpContext!.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            return res is not null ? Enum.Parse<UserRole>(res.Value) : null;
        }
    }
}
