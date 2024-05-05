using Microsoft.AspNetCore.Http;
using Perakaravan.InfraPack.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;



namespace Perakaravan.InfraPack.Utils
{
    public static class ProcessImageHelper
    {
        private static Dictionary<FileType, byte[]> fileTypes = new Dictionary<FileType, byte[]>
            {
                {FileType.Jpg, new byte[]{ 255, 216, 255 } },
                {FileType.Png, new byte[]{ 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 } },
                {FileType.Gif, new byte[]{ 71, 73, 70, 56 } },
                {FileType.Bmp, new byte[]{ 66, 77 } }
            };

        public static string GenerateFileName(IFormFile file)
        {
            var now = DateTime.UtcNow.ToTurkeyLocalTime();
            return $"{now.Day}_{now.Month}_{now.Year}_{now.Hour}_{now.Minute}_{now.Second}_{now.Millisecond}.{GetExtensionByFile(file)}";
        }

        public static string GetContentTypeByFile(IFormFile file)
        {
            byte[] buffer = new byte[20]; // İlk 20 byte'ı okuyarak MIME türünü belirleyeceğiz
            file.OpenReadStream().Read(buffer, 0, 20);

            if (buffer.Take(3).SequenceEqual(fileTypes[FileType.Jpg]))
                return "image/jpeg";
            else if (buffer.Take(16).SequenceEqual(fileTypes[FileType.Png]))
                return "image/png";
            else if (buffer.Take(4).SequenceEqual(fileTypes[FileType.Gif]))
                return "image/gif";
            else if (buffer.Take(2).SequenceEqual(fileTypes[FileType.Bmp]))
                return "image/bmp";
            else
                throw new Exception("Unsupported Media Type");
        }

        public static string GetExtensionByFile(IFormFile file)
        {
            byte[] buffer = new byte[20]; // İlk 20 byte'ı okuyarak MIME türünü belirleyeceğiz
            file.OpenReadStream().Read(buffer, 0, 20);

            if (buffer.Take(3).SequenceEqual(fileTypes[FileType.Jpg]))
                return "jpg";
            else if (buffer.Take(16).SequenceEqual(fileTypes[FileType.Png]))
                return "png";
            else if (buffer.Take(4).SequenceEqual(fileTypes[FileType.Gif]))
                return "gif";
            else if (buffer.Take(2).SequenceEqual(fileTypes[FileType.Bmp]))
                return "bmp";            
            else
                throw new Exception("Unsupported Media Type");
        }

        public static FileType GetFileType(IFormFile file)
        {
            byte[] buffer = new byte[20]; // İlk 20 byte'ı okuyarak MIME türünü belirleyeceğiz
            file.OpenReadStream().Read(buffer, 0, 20);

            if (buffer.Take(3).SequenceEqual(fileTypes[FileType.Jpg]))
                return FileType.Jpg;
            else if (buffer.Take(16).SequenceEqual(fileTypes[FileType.Png]))
                return FileType.Png;
            else if (buffer.Take(4).SequenceEqual(fileTypes[FileType.Gif]))
                return FileType.Gif;
            else if (buffer.Take(2).SequenceEqual(fileTypes[FileType.Bmp]))
                return FileType.Bmp;            
            else
            {
                return FileType.Unknown;
            }
        }

        public static Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            // Calculate the scaling factor to maintain aspect ratio
            float widthRatio = (float)maxWidth / image.Width;
            float heightRatio = (float)maxHeight / image.Height;
            float resizeRatio = Math.Min(widthRatio, heightRatio);

            // Calculate the new dimensions
            int newWidth = (int)(image.Width * resizeRatio);
            int newHeight = (int)(image.Height * resizeRatio);

            // Resize the image while preserving aspect ratio
            image.Mutate(x => x.Resize(newWidth, newHeight));

            //// Save the resized image
            //using (FileStream outputStream = File.Create(outputImagePath))
            //{
            //    var encoder = new JpegEncoder();
            //    image.Save(outputStream, encoder);
            //}
            return image;
        }

    }

    public enum FileType
    {
        Bmp = 1,
        Gif = 2,
        Jpg = 4,
        Jpeg = 5,
        Png = 6,
        Unknown = 7
    }
}
