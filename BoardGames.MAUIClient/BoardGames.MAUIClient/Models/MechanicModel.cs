using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Models
{
    public class MechanicModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<GameModel>? Games { get; set; }
    }
}
