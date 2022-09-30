namespace BoardGames.Services.Models
{
    public record CreateGenreDto
    {
        public string Name { get; set; }
        public byte[]? Image { get; set; }

    }
}
