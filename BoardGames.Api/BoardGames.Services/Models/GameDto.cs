namespace BoardGames.Services.Models
{
    public class GameDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public GenreDto Genre { get; set; }
        public IEnumerable<MechanicDto> Mechanics { get; set; }
    }
}
