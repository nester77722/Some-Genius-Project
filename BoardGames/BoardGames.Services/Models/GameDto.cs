namespace BoardGames.Services.Models
{
    public class GameDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string GenreId { get; set; }
        public string? GenreName { get; set; }
        public IEnumerable<string>? MechanicNames { get; set; }
        public IEnumerable<string> MechanicIds { get; set; }
    }
}
