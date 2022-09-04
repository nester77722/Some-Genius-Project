using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BoardGames.MAUIClient.ViewModels
{
    [QueryProperty("GenreId", "GenreId")]
    public partial class GenreViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IGenreService _genreService;

        [ObservableProperty]
        private GenreModel _genre;

        [ObservableProperty]
        private bool _isValid;

        public GenreViewModel(IGenreService genreService)
        {

            _genreService = genreService;
        }

        public GenreViewModel(GenreModel genre)
        {
            _genre = genre;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Genre = query["Genre"] as GenreModel;
            Genre.PropertyChanged += CheckName;
        }

        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.GoToAsync(nameof(GenresListPage));
        }

        [RelayCommand]
        private async Task DeleteGenre()
        {
            if (!string.IsNullOrWhiteSpace(_genre.Id) && _genre.Id != "0")
            {
                await _genreService.DeleteGenre(_genre);
            }
            await Back();
        }

        [RelayCommand]
        private async Task SaveGenre()
        {
            if (string.IsNullOrWhiteSpace(_genre.Id))
            {
                await _genreService.CreateGenre(_genre);
            }


            await Back();
        }

        private void CheckName(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Genre.Name))
            {
                IsValid = IsValidName();
            }
        }

        private bool IsValidName()
        {
            return !string.IsNullOrWhiteSpace(Genre.Name) && Genre.Name.Length > 3;
        }
    }
}