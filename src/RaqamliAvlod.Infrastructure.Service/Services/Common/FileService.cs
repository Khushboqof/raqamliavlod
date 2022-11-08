using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;

namespace RaqamliAvlod.Infrastructure.Service.Services.Common
{
    public class FileService : IFileService
    {
        private readonly string _basePath = string.Empty;
        private readonly string _imageFolderName = "images";

        public FileService(IWebHostEnvironment webHost)
        {
            _basePath = webHost.WebRootPath;
        }

        string IFileService.ImageFolderName => _imageFolderName;

        public async Task<string> SaveImageAsync(IFormFile image)
        {
            if(image is null)
                return "";

            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }

            if (!Directory.Exists(Path.Combine(_basePath, _imageFolderName)))
            {
                Directory.CreateDirectory(Path.Combine(_basePath, _imageFolderName));
            }

            string fileName = ImageHelper.MakeImageName(image.FileName);
            string partPath = Path.Combine(_imageFolderName, fileName);
            string path = Path.Combine(_basePath, partPath);

            var stream = File.Create(path);
            await image.CopyToAsync(stream);
            stream.Close();

            return partPath;
        }

        public Task<bool> DeleteImageAsync(string relativeFilePath)
        {
            string absoluteFilePath = Path.Combine(_basePath, relativeFilePath);

            if (!File.Exists(absoluteFilePath)) return Task.FromResult(false);

            try
            {
                File.Delete(absoluteFilePath);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
