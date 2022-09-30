namespace BoardGames.Services.Models
{
    public record CreateGameDto
    {
        public string Name { get; set; }
        public Guid GenreId { get; set; }
        public List<Guid> MechanicIds { get; set; }
        public byte[]? Image { get; set; }
    }
}
