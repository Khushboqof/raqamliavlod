﻿using RaqamliAvlod.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos;

public class UserResetPasswordDto
{
    [Required(ErrorMessage = "Email is required"), Email]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int Code { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}
