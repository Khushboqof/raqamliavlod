namespace RaqamliAvlod.Infrastructure.Service.Helpers
{
    public class ImageHelper
    {
        public static string MakeImageName(string fileName)
        {
            string strpath = Path.GetExtension(fileName);

            string guid = Guid.NewGuid().ToString();
            return "IMG_" + guid + strpath;
        }
    }
}
