using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.RefitClients;
using BoardGames.MAUIClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRefitClient _gameClient;

        public GameService(IGameRefitClient gameClient)
        {
            _gameClient = gameClient;
        }

        public async Task<GameModel> GetGame(string id)
        {
            var game = await _gameClient.GetGame(id);

            return game;
        }

        public Task<IEnumerable<GameModel>> GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
