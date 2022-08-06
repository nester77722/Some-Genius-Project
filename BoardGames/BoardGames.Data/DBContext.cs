using BoardGames.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGames.Data.ContextConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BoardGames.Data
{
    public class DBContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
