using BoardGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Services.Intefraces
{
    public interface IGenreService
    {
        public Task<List<GenreDto>> GetAllAsync();
        public Task<GenreDto> GetAsync(string id);
        public Task<GenreDto> CreateAsync(GenreDto genreDto);
        public Task<GenreDto> UpdateAsync(GenreDto genreDto);
        public Task DeleteAsync(string id);
    }
}
