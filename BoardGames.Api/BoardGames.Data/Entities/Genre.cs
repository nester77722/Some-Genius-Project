﻿namespace BoardGames.Data.Entities
{
    public class Genre : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Game>? Games { get; set; }
    }
}
