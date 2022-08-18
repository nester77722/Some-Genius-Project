using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGames.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Mechanic> _mechanicRepository;
        private readonly IMapper _mapper;

        public GameService(IRepository<Game> repository, IMapper mapper, IRepository<Mechanic> mechanicRepository)
        {
            _gameRepository = repository;
            _mapper = mapper;
            _mechanicRepository = mechanicRepository;
        }

        public async Task<GameDto> CreateAsync(GameDto gameDto)
        {
            var game = _mapper.Map<Game>(gameDto);
            game.Id = Guid.NewGuid();
            //game.GenreId = Guid.Parse(gameDto.GenreId);

            //var ids = _mapper.Map<List<Guid>>(gameDto.MechanicIds);

            //var mechanics = _mechanicRepository.GetAll().Where(me => ids.Contains(me.Id));

            //game.Mechanics = await mechanics.ToListAsync();

            await _gameRepository.CreateAsync(game);

            var result = _mapper.Map<GameDto>(game);

            return result;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GameDto>> GetAllAsync()
        {
            var games = await _gameRepository.GetAll()
                                             .Include(g => g.Genre)
                                             .Include(g => g.Mechanics)
                                             .ToListAsync();

            var result = _mapper.Map<List<GameDto>>(games);

            return result;
        }

        public async Task<GameDto> GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            Guid gameId;

            if (!Guid.TryParse(id, out gameId))
            {
                return null;
            }

            var game = await _gameRepository.GetAsync(gameId,
                                                      include => include.Genre,
                                                      include => include.Mechanics);

            if (game is null)
            {
                return null;
            }

            var result = _mapper.Map<GameDto>(game);

            return result;
        }

        public Task<GameDto> UpdateAsync(GameDto gameDto)
        {
            throw new NotImplementedException();
        }
    }
}
