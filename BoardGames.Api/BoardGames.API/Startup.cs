using AutoMapper;
using BoardGames.API.Configurations;
using BoardGames.API.Middleware;
using BoardGames.API.StartupExtensions;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.OpenApi.Models;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace BoardGames.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.WithOrigins("http://localhost:4200")
            //                          .WithOrigins("http://localhost:63342")
            //                          .WithOrigins("http://localhost:65244")
            //                          .AllowAnyMethod()
            //                          .AllowAnyHeader()
            //                          .AllowCredentials());
            //});

            services.Configure<KestrelServerOptions>(options =>
            {
                options.ConfigureHttpsDefaults(options =>
                    options.ClientCertificateMode = ClientCertificateMode.NoCertificate);
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.ConfigureSqlServerContext(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ConfigureScops();


            services.AddSignalR();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors("CorsPolicy");
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
