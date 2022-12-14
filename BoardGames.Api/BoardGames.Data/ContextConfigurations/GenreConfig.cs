using BoardGames.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGames.Data.ContextConfigurations
{
    internal class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            //builder.HasOne(g => g.Image).WithOne()
            //       .HasForeignKey<Genre>(g => g.ImageId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
