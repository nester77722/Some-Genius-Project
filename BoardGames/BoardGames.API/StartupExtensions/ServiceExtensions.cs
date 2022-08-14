using BoardGames.API.Configurations;
using BoardGames.API.Services;
using BoardGames.API.Services.Interfaces;
using BoardGames.Data;
using BoardGames.Data.Entities;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMechanicService, MechanicService>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole<Guid>>().AddEntityFrameworkStores<DBContext>();

            var jwtSection = configuration.GetSection("JwtBearerTokenSettings");
            services.Configure<JwtBearerTokenSettings>(jwtSection);
            var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();

            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtBearerTokenSettings.Issuer,
                    ValidAudience = jwtBearerTokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });
        }
    }
}
