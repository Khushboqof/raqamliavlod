using RaqamliAvlod.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Dtos;

public class SendToEmailDto
{
    [Required(ErrorMessage = "Email is required"), Email]
    public string Email { get; set; } = string.Empty;
}
