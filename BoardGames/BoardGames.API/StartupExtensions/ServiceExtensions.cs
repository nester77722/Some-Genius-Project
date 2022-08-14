using BoardGames.Data;
using Microsoft.EntityFrameworkCore;

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

        public static void ConfigureScops(this IServiceCollection services)
        {
            services.AddScoped(typeof(Data.Repository.IRepository<>), typeof(Data.Repository.Repository<>));
        }
    }
}
