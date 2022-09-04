using BoardGames.MAUIClient.RefitClients;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.ViewModels;

namespace BoardGames.MAUIClient.Views;

public partial class GenresListPage : ContentPage
{
    public GenresListPage(GenresListViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

}