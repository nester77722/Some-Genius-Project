using BoardGames.Services.Models;

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
