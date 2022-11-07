using RaqamliAvlod.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
