using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.Views;

namespace BoardGames.MAUIClient;

public partial class App : Application
{
	public App(GenresListPage genresListPage, IGenreService genreService)
	{
		InitializeComponent();

		MainPage = new NavigationPage(genresListPage);
	}
}
