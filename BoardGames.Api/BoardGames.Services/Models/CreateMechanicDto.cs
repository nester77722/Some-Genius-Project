namespace BoardGames.Services.Models
{
    public record CreateMechanicDto
    {
        public string Name { get; set; }
        public byte[]? Image { get; set; }

    }
}
