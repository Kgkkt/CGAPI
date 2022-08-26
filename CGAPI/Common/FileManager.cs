namespace CGAPI.Common
{
    public class FileManager
    {
        public static byte[] GetBytes(List<IFormFile> file)
        {
            var f = file.FirstOrDefault();
            if (f != null)
            {
                using (var ms = new MemoryStream())
                {
                    f.CopyTo(ms);
                    return ms.ToArray().Compress();

 
                }
            }
            else
            {
                return null;
            }
        }
    }
}
