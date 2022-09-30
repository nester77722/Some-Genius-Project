using BoardGames.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGames.Data.ContextConfigurations
{
    internal class MechanicConfig : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.Games).WithMany(g => g.Mechanics);

            //builder.HasOne(m => m.Image).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
