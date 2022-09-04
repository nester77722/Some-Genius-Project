using BoardGames.MAUIClient.ViewModels;
using BoardGames.MAUIClient.Views;

namespace BoardGames.MAUIClient;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(GenrePage), typeof(GenrePage));
        Routing.RegisterRoute(nameof(GenresListPage), typeof(GenresListPage));

    }
}
