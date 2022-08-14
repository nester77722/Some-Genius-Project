using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Data.Entities
{
    public class Game : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Genre? Genre { get; set; }
        public Guid? GenreId { get; set; }
        public IEnumerable<Mechanic>? Mechanics { get; set; }
    }
}
