namespace BoardGames.Services.Models
{
    public record GetGenreWithGamesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetGameDto>? Games { get; set; }
    }
}
