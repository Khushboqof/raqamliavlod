using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Infrastructure.Service.Dtos.Accounts
{
    public class ImageUploadDto
    {
        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2)]
        [AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile Image { get; set; } = null!;
    }
}
