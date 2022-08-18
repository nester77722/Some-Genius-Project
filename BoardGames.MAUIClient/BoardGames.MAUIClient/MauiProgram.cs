using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

namespace BoardGames.MAUIClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Configuration
			.AddJsonStream(
			Assembly.GetExecutingAssembly()
			.GetManifestResourceStream("BoardGames.MAUIClient.appsettings.json"));

		var config = builder.Configuration;

		var loggerConfigurations = new LoggerConfiguration()
											  .WriteTo.Http(
#if ANDROID
												requestUri: "http://10.0.2.2:5202/api/Logger",
#else
                                                requestUri: "http://localhost:5202/api/Logger",
#endif
                                                queueLimitBytes: null,
												restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose,
												httpClient: new SerilogHttpClient())
											  .Enrich.WithProperty("Device", DeviceInfo.Current.Platform)

											  .Enrich.FromLogContext();

		Log.Logger = loggerConfigurations.CreateLogger();
		builder.Logging.AddSerilog();

		return builder.Build();
	}
}
