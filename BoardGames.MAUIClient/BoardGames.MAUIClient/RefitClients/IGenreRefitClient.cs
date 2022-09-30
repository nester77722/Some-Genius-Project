using BoardGames.MAUIClient.Models;
using BoardGames.MAUIClient.Models.Authentication;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.RefitClients
{
    public interface IGenreRefitClient
    {
        [Get("/Genre")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<IEnumerable<GenreModel>> GetGenres();

        [Get("/Genre/{id}")]
        Task<GenreModel> GetGenre(string id);
    }
}
