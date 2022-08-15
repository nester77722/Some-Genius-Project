﻿using BoardGames.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGames.Data.ContextConfigurations
{
    internal class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Genre);

            builder.HasMany(g => g.Mechanics).WithMany(m => m.Games);
        }
    }
}
