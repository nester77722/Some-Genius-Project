using BoardGames.Services.Models;

namespace BoardGames.Services.Intefraces
{
    public interface IGameService
    {
        public Task<List<GetGameWithoutDetails>> GetAllAsync();
        public Task<GetGameDto> GetAsync(string id);
        public Task<GetGameDto> CreateAsync(CreateGameDto gameDto);
        public Task<GetGameDto> UpdateAsync(GetGameDto gameDto);
        public Task DeleteAsync(string id);
    }
}
