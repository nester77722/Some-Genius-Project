using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThumbnailSharp;
using System.Threading.Tasks;
using System.IO;

namespace BoardGames.Services.Helpers
{
    public static class ImageHelper
    {

        public static byte[] CreateThumbnail(byte[] image)
        {
            var creator = new ThumbnailCreator();

            var result = creator.CreateThumbnailBytes(thumbnailSize: 100, image, Format.Jpeg);

            return result;
        }

        public static async Task<byte[]> DefaultImage()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", "defaultImage.png");
            var result = await ReadImageAsync(path);

            return result;

        }

        public static async Task<byte[]> DefaultAvatar()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", "defaultAvatar.jpg");
            var result = await ReadImageAsync(path);

            return result;
        }

        private static async Task<byte[]> ReadImageAsync(string path)
        {
            var result = await File.ReadAllBytesAsync(path);

            return result;
        }
    }
}
