using Microsoft.AspNetCore.Http;

namespace RaqamliAvlod.Infrastructure.Service.Helpers
{
    public class FileReader
    {
        public static byte[] ReadAsBytes(IFormFile file)
        {
            byte[] bytefile;
            using (var reader = new BinaryReader(file.OpenReadStream()))
            {
                bytefile = reader.ReadBytes((int)file.OpenReadStream().Length);
            }
            return bytefile;
        }
    }
}