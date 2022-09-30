using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.Services.Interfaces;
using BoardGames.MAUIClient.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace BoardGames.MAUIClient.ViewModels
{
    [QueryProperty("GenreId", "GenreId")]
    public partial class GenreViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IGenreService _genreService;
        [ObservableProperty]
        private string _errors;

        [ObservableProperty]
        private GenreModel _genre;

        [ObservableProperty]
        private bool _hasErrors;

        [ObservableProperty]
        private bool _hasGames;

        public GenreViewModel(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = query["GenreId"] as string;

            if (!string.IsNullOrWhiteSpace(id))
            {
                Genre = await _genreService.GetGenre(id);
            }
            else
            {
                Genre = new GenreModel();
            }

            HasGames = _genre.Games.Any();
        }

        [RelayCommand]
        private Task Back() => Shell.Current.GoToAsync("..");

        [RelayCommand]
        private Task NavigateToGame(GameModel game) => Shell.Current.GoToAsync($"{nameof(GamePage)}",
                                                                        parameters: new Dictionary<string, object>
                                                                        {
                                                                            {"GameId", game.Id}
                                                                        });

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
            if (_genre.HasErrors)
            {
                HasErrors = true;
                Errors = string.Join("", _genre.GetErrors().Select(e => e.ErrorMessage));
            }
            else
            {
                if (string.IsNullOrWhiteSpace(_genre.Id))
                {
                    await _genreService.CreateGenre(_genre);
                }


                await Back();
            }
        }
    }
}