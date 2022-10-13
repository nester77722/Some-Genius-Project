using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BoardGames.Services.Helpers
{
    public static class ImageHelper
    {
        private const int _thumbnailHeight = 100;
        private const int _thumbnailWidth = 100;
        private const int _normalizedHeight = 500;
        private const int _normalizedWidth = 500;


        public static byte[] CreateThumbnail(byte[] imageBytes)
        {
            using MemoryStream ms = new MemoryStream(imageBytes);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            var imag = ScaleImage(image, _thumbnailHeight, _thumbnailWidth);

            using MemoryStream ms1 = new MemoryStream();
            imag.Save(ms1, image.RawFormat);
            byte[] result = ms1.ToArray();

            return result;
        }

        public static byte[] ResizeImage(byte[] imageBytes)
        {
            using MemoryStream ms = new MemoryStream(imageBytes);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            var imag = ScaleImage(image, _normalizedHeight, _normalizedWidth);

            using MemoryStream ms1 = new MemoryStream();
            imag.Save(ms1, image.RawFormat);
            byte[] result = ms1.ToArray();

            return result;
        }

        public static async Task<byte[]> DefaultImage()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", "defaultImage.png");
            var result = await ReadImageAsync(path);

            return ResizeImage(result);

        }

        public static async Task<byte[]> DefaultAvatar()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", "defaultAvatar.jpg");
            var result = await ReadImageAsync(path);

            return ResizeImage(result);
        }

        private static async Task<byte[]> ReadImageAsync(string path)
        {
            var result = await File.ReadAllBytesAsync(path);

            return result;
        }

        private static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
