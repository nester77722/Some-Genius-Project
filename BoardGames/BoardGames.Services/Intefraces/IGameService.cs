using BoardGames.Services.Models;

namespace BoardGames.Services.Intefraces
{
    public interface IGameService
    {
        public Task<List<GameDto>> GetAllAsync();
        public Task<GameDto> GetAsync(string id);
        public Task<GameDto> CreateAsync(GameDto gameDto);
        public Task<GameDto> UpdateAsync(GameDto gameDto);
        public Task DeleteAsync(string id);
    }
}
