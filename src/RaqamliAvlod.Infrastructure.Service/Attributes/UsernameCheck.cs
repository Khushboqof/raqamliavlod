using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UsernameCheck : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var usernmae = (string)value!;

            if (!usernmae.Contains('@'))
                return ValidationResult.Success;

            return new ValidationResult($"Cannot use '@' symbol");
        }
    }
}
