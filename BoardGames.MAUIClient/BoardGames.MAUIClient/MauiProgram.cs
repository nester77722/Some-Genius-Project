using BoardGames.MAUIClient.Extensions;
using BoardGames.MAUIClient.Services;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.ViewModels;
using BoardGames.MAUIClient.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Serilog;
using System.Reflection;

namespace BoardGames.MAUIClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
//#if DEBUG
//		builder.Configuration.AddInMemoryCollection(
//			new Dictionary<string, string>
//			{
//				{"environment", "development" }
//            });
//#else
//		builder.Configuration.AddInMemoryCollection(
//			new Dictionary<string, string>
//			{
//				{"environment", "production" }
//            });
//#endif

		//var environment = builder.Configuration.GetValue<string>("environment");

        builder.Configuration
			.AddJsonStream(Assembly.GetExecutingAssembly()
								   .GetManifestResourceStream($"BoardGames.MAUIClient.appsettings.production.json"));

		builder.Services.AddSingleton<IAuthService, AuthService>();
		builder.Services.AddSingleton<IGenreService, GenreService>();
		builder.Services.AddSingleton<IGameService, GameService>();

		builder.Services.AddTransient<GenresListPage>();
		builder.Services.AddTransient<GenrePage>();
		builder.Services.AddTransient<GamePage>();
        builder.Services.AddTransient<MainPage>();

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<GenresListViewModel>();
		builder.Services.AddTransient<GenreViewModel>();
		builder.Services.AddTransient<GameViewModel>();

		builder.ConfigureSerilog();
		builder.ConfigureRefitClients();

		

		return builder.Build();
	}
}
