using BoardGames.MAUIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Services.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameModel>> GetGames();
        Task<GameModel> GetGame(string id);
        Task CreateGame(GameModel game);
        Task DeleteGenre(GameModel game);
    }
}
