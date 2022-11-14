using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RaqamliAvlod.Infrastructure.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string phoneNumber = (string)value!;
            Regex regex = new Regex("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$");

            return regex.Match(phoneNumber).Success ? ValidationResult.Success
                : new ValidationResult("Please enter valid phone number. Phone must be contains only numbers or + character");
        }
    }
}
