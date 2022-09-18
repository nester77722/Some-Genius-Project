using BoardGames.Services.Models;

namespace BoardGames.Services.Intefraces
{
    public interface IMechanicService
    {
        public Task<List<GetMechanicWithGamesDto>> GetAllAsync();
        public Task<List<GetMechanicWithoutGamesDto>> GetAllWithoutGamesAsync();
        public Task<GetMechanicWithGamesDto> GetAsync(string id);
        public Task<GetMechanicWithGamesDto> CreateAsync(CreateMechanicDto mechanicDto);
        public Task<GetMechanicWithGamesDto> UpdateAsync(GetMechanicWithGamesDto mechanicDto);
        public Task DeleteAsync(string id);
    }
}
