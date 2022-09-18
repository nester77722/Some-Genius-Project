namespace BoardGames.Data.Entities
{
    public class Game : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public List<Mechanic>? Mechanics { get; set; }
    }
}
