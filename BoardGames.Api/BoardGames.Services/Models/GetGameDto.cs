namespace BoardGames.Services.Models
{
    public record GetGameDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public GetGenreWithoutGamesDto Genre { get; set; }
        public IEnumerable<GetMechanicWithoutGamesDto> Mechanics { get; set; }
    }
}
