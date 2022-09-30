﻿namespace BoardGames.Services.Models
{
    public record GetGenreWithGamesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetGameWithoutDetailsDto>? Games { get; set; }
        public byte[]? Image { get; set; }
        public byte[]? Thumbnail { get; set; }
    }
}
