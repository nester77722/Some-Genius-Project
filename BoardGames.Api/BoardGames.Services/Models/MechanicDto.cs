﻿namespace BoardGames.Services.Models
{
    public class MechanicDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GameDto>? Games { get; set; }
    }
}
