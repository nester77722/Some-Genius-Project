using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.Services;
using BoardGames.MAUIClient.Services.Interfaces;
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
    public partial class GameViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IGameService _gameService;
        [ObservableProperty]
        private string _errors;

        [ObservableProperty]
        private GameModel _game;

        [ObservableProperty]
        private bool _hasErrors;

        public GameViewModel(IGameService gameService)
        {
            _gameService = gameService;
        }
 
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = query["GameId"] as string;

            if (!string.IsNullOrWhiteSpace(id))
            {
                Game = await _gameService.GetGame(id);
            }
            else
            {
                Game = new GameModel();
            }
        }

        [RelayCommand]
        private Task Back() => Shell.Current.GoToAsync("..");

        [RelayCommand]
        private Task NavigateToGenre(GenreModel genre) => Shell.Current.GoToAsync($"{nameof(GenrePage)}",
                                                                        parameters: new Dictionary<string, object>
                                                                        {
                                                                            {"GenreId", genre.Id}
                                                                        });
    }
}
