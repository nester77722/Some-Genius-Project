using BoardGames.MAUIClient.ViewModels;

namespace BoardGames.MAUIClient.Views;

public partial class GamePage : ContentPage
{
	public GamePage(GameViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}