using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Services.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public int? Age { get; set; }
        public string UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public byte[]? Image { get; set; }

    }
}
