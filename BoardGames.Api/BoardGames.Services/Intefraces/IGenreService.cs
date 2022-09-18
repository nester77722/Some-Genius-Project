using BoardGames.Services.Models;

namespace BoardGames.Services.Intefraces
{
    public interface IGenreService
    {
        public Task<List<GetGenreWithGamesDto>> GetAllAsync();
        public Task<List<GetGenreWithoutGamesDto>> GetAllWithoutGamesAsync();
        public Task<GetGenreWithGamesDto> GetAsync(string id);
        public Task<GetGenreWithGamesDto> CreateAsync(CreateGenreDto genreDto);
        public Task<GetGenreWithGamesDto> UpdateAsync(GetGenreWithGamesDto genreDto);
        public Task DeleteAsync(string id);
    }
}
