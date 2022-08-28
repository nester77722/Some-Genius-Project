using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Models
{
    public class GenreModel
    {
        public GenreModel()
        {
            Id = string.Empty;
            Name = string.Empty;
        }

        public GenreModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string? Id { get; set; }
        public string? Name { get; set; }
        
    }
}
