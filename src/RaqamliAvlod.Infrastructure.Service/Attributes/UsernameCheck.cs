using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Attributes
{
    public class UsernameCheck : ValidationAttribute
    {
        [AttributeUsage(AttributeTargets.Property)]
         
    }
}
