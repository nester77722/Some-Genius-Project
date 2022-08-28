using BoardGames.MAUIClient.RefitClients;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.ViewModels;

namespace BoardGames.MAUIClient.Views;

public partial class GenresListPage : ContentPage
{
    public GenresListPage(IGenreService genreService)
    {
        InitializeComponent();
        BindingContext = new GenresListViewModel(genreService) { Navigation = this.Navigation };
    }

}