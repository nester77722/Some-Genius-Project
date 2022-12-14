namespace BoardGames.Services.Models
{
    public record GetMechanicWithoutGamesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public byte[]? Thumbnail { get; set; }
    }
}
