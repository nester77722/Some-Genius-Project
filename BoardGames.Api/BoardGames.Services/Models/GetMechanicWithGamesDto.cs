namespace BoardGames.Services.Models
{
    public record GetMechanicWithGamesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetGameDto>? Games { get; set; }
        public byte[]? Image { get; set; }
        public byte[]? Thumbnail { get; set; }
    }
}
