using BoardGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
