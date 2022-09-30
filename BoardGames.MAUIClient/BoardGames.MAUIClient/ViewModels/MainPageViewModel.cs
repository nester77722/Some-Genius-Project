using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [RelayCommand]
        private Task NavigateToGenres() => Shell.Current.GoToAsync(nameof(GenresListPage));
    }
}
