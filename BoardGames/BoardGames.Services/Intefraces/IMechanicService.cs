using BoardGames.Services.Models;

namespace BoardGames.Services.Intefraces
{
    public interface IMechanicService
    {
        public Task<List<MechanicDto>> GetAllAsync();
        public Task<MechanicDto> GetAsync(string id);
        public Task<MechanicDto> CreateAsync(MechanicDto mechanicDto);
        public Task<MechanicDto> UpdateAsync(MechanicDto mechanicDto);
        public Task DeleteAsync(string id);
    }
}
