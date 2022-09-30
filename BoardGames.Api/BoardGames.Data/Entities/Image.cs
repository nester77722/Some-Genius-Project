using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Data.Entities
{
    public class Image : IEntity
    {
        public Guid Id { get; set; }
        public byte[] ImageData { get; set; }
        public byte[] ThumbnailData { get; set; }
    }
}
