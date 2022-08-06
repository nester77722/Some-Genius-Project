using Microsoft.EntityFrameworkCore;
using BoardGames.Data;

namespace BoardGames.API.StartupExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
