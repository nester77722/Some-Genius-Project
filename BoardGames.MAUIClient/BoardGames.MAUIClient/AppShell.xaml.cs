using BoardGames.MAUIClient.ViewModels;
using BoardGames.MAUIClient.Views;

namespace BoardGames.MAUIClient;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(GenrePage), typeof(GenrePage));
        Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
    }
}
