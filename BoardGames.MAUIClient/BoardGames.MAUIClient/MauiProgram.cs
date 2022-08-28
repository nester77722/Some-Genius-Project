using BoardGames.MAUIClient.Extensions;
using BoardGames.MAUIClient.Services;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.Views;
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

		builder.Services.AddScoped<IAuthService, AuthService>();
		builder.Services.AddScoped<IGenreService, GenreService>();
		builder.Services.AddSingleton<GenresListPage>();


		builder.ConfigureSerilog();
		builder.ConfigureRefitClients();

		

		return builder.Build();
	}
}
