using Microsoft.AspNetCore.Http;
using RaqamliAvlod.Infrastructure.Service.Helpers;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Services.Common
{
    public class FileService : IFileService
    {
        private readonly string _basePath = string.Empty;
        private readonly string _imageFolderName = "images";

        //public FileService(IWebHostEnvironment webHost)
        //{
        //    _basePath = webHost.WebRootPath;
        //    if (!Directory.Exists(_basePath))
        //    {
        //        Directory.CreateDirectory(_basePath);
        //    }
        //    string imagepath = Path.Combine(_basePath, _imageFolderName);
        //    if (!Directory.Exists(imagepath))
        //    {
        //        Directory.CreateDirectory(imagepath);
        //    }
        //}

        ///<summary>
        ///this method th file save
        ///<summary>
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            string fileName = ImageHelper.MakeImageName(file.FileName);
            string partPath = Path.Combine(_imageFolderName, fileName);
            string path = Path.Combine(_basePath, partPath);

            var stream = File.Create(path);
            await file.CopyToAsync(stream);
            stream.Close();

            return partPath;
        }
    }
}
