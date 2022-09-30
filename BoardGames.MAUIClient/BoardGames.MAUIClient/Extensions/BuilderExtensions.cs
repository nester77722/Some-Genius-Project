using BoardGames.MAUIClient.RefitClients;
using Microsoft.Extensions.Configuration;
using Refit;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Extensions
{
    public static class BuilderExtensions
    {
        public static void ConfigureSerilog(this MauiAppBuilder builder)
        {
            var config = builder.Configuration;

            var androidUri = builder.Configuration.GetSection("Serilog").GetRequiredSection("AndroidAddress");
            var windowsUri = builder.Configuration.GetSection("Serilog").GetRequiredSection("WindowsAddress");


            var loggerConfigurations = new LoggerConfiguration()
                                              .WriteTo.Http(
#if ANDROID
                                                requestUri: androidUri.Value,
#else
                                                requestUri: windowsUri.Value,
#endif
                                                queueLimitBytes: null,
                                                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                                                httpClient: new SerilogHttpClient())
                                              .Enrich.WithProperty("Device", DeviceInfo.Current.Platform)

                                              .Enrich.FromLogContext();

            Log.Logger = loggerConfigurations.CreateLogger();
            builder.Logging.AddSerilog();
        }

        public static void ConfigureRefitClients(this MauiAppBuilder builder)
        {
#if ANDROID
            var uri = builder.Configuration.GetSection("RefitClient").GetRequiredSection("AndroidAddress");
#else
            var uri = builder.Configuration.GetSection("RefitClient").GetRequiredSection("WindowsAddress");

#endif

            builder.Services.AddRefitClient<IAuthenticationRefitClient>()
                              .ConfigureHttpClient(c => c.BaseAddress = new Uri(uri.Value))
                              .SetHandlerLifetime(TimeSpan.FromDays(1));

            builder.Services.AddRefitClient<IGenreRefitClient>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(uri.Value))
                    .AddHttpMessageHandler<AuthHeaderHandler>()
                    .SetHandlerLifetime(TimeSpan.FromDays(1));

            builder.Services.AddRefitClient<IGameRefitClient>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(uri.Value))
                    .AddHttpMessageHandler<AuthHeaderHandler>()
                    .SetHandlerLifetime(TimeSpan.FromDays(1));

            builder.Services.AddScoped<AuthHeaderHandler>();

        }
    }
}
