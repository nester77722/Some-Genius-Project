using BoardGames.MAUIClient.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.RefitClients
{
    public interface IGameRefitClient
    {
        [Get("/Game")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<IEnumerable<GameModel>> GetGames();

        [Get("/Game/{id}")]
        Task<GameModel> GetGame(string id);
    }
}
