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

        [ObservableProperty]
        private bool _isLoadingGenres;

        public GenresListViewModel(IGenreService genreService)
        {
            Genres = new ObservableCollection<GenreModel>();
            _genreService = genreService;

            GetGenres();
        }

        #region Commands

        [RelayCommand]
        private Task NavigateToGenre(GenreModel genre) => Shell.Current.GoToAsync($"{nameof(GenrePage)}",
                                                                        parameters: new Dictionary<string, object>
                                                                        {
                                                                            {"GenreId", genre.Id}
                                                                        });

        [RelayCommand]
        private Task Back() => Shell.Current.GoToAsync("..");
        
        [RelayCommand]
        private async Task GetGenres()
        {
            IsLoadingGenres = true;
            var genres = await _genreService.GetGenres();

            var newCollection = new ObservableCollection<GenreModel>();

            foreach (var item in genres)
            {
                newCollection.Add(item);
            }

            Genres = newCollection;
            IsLoadingGenres = false;
        }

        #endregion
    }
}
