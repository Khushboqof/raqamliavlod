using Microsoft.AspNetCore.Http;

namespace RaqamliAvlod.Infrastructure.Service.Interfaces.Common
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile file);
    }
}
