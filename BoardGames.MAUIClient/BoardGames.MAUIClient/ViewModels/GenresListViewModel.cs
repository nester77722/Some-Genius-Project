using BoardGames.MAUIClient.Extensions;
using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BoardGames.MAUIClient.ViewModels
{
    public partial class GenresListViewModel : ObservableObject
    {
        private readonly IGenreService _genreService;

        [ObservableProperty]
        private ObservableCollection<GenreModel> _genres;

        public GenresListViewModel(IGenreService genreService)
        {
            Genres = new ObservableCollection<GenreModel>();
            _genreService = genreService;

            GetGenres();
        }

        #region Commands

        [RelayCommand]
        private async Task NavigateToGenre(GenreModel genre)
        {
            await Shell.Current.GoToAsync($"{nameof(GenrePage)}",
                parameters: new Dictionary<string, object>
                {
                    {"Genre", genre}
                });
        }

        [RelayCommand]
        private async Task CreateGenre()
        {
            await NavigateToGenre(new GenreModel());
        }
        [RelayCommand]
        private async Task DeleteGenre(GenreModel genre)
        {
            await _genreService.DeleteGenre(genre);

            await GetGenres();
        }
        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.GoToAsync("../");
        }
        
        [RelayCommand]
        private async Task GetGenres()
        {
            var genres = await _genreService.GetGenres();

            var newCollection = new ObservableCollection<GenreModel>();

            foreach (var item in genres)
            {
                newCollection.Add(item);
            }

            Genres = newCollection;
        }

        #endregion
    }
}
