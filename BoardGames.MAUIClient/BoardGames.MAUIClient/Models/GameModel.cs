using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Models
{
    public class GameModel
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public GenreModel Genre { get; set; }
        public IEnumerable<MechanicModel> Mechanics { get; set; }
    }
}
