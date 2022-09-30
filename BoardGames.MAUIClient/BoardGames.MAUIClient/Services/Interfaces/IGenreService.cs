using BoardGames.MAUIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.MAUIClient.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreModel>> GetGenres();
        Task<GenreModel> GetGenre(string id);
    }
}
