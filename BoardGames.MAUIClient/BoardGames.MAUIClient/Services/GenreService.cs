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

        public async Task CreateGenre(GenreModel genre)
        {
            var body = new GenreModel() { Name = genre.Name };

            await _genreClient.CreateGenre(body);
        }

        public async Task DeleteGenre(GenreModel genre)
        {
            await _genreClient.DeleteGenre(genre.Id);
        }

        public async Task<IEnumerable<GenreModel>> GetGenres()
        {
            var genres = await _genreClient.GetGenres();

            return genres;
        }
    }
}
