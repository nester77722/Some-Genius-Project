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
    public class GenreService : IGenreService
    {
        private readonly IGenreRefitClient _genreClient;

        public GenreService(IGenreRefitClient genreClient)
        {
            _genreClient = genreClient;
        }

        public async Task<GenreModel> GetGenre(string id)
        {
            var genre = await _genreClient.GetGenre(id);

            return genre;
        }

        public async Task<IEnumerable<GenreModel>> GetGenres()
        {
            var genres = await _genreClient.GetGenres();

            return genres;
        }
    }
}
