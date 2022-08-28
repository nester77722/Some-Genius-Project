using BoardGames.MAUIClient.ViewModels;

namespace BoardGames.MAUIClient.Views;

public partial class GenrePage : ContentPage
{
    public GenreViewModel ViewModel { get; private set; }
    public GenrePage(GenreViewModel vm)
    {
        InitializeComponent();

        ViewModel = vm;
        this.BindingContext = ViewModel;
    }
}