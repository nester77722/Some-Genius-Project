using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.Views;

namespace BoardGames.MAUIClient;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
