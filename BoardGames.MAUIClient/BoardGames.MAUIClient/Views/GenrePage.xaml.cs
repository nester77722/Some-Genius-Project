using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.ViewModels;

namespace BoardGames.MAUIClient.Views;

public partial class GenrePage : ContentPage
{
    public GenrePage(GenreViewModel vm)
    {
        InitializeComponent();

        this.BindingContext = vm;
    }
}