using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using BoardGames.Shared.Exceptions.GameServiceExceptions;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BoardGames.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Mechanic> _mechanicRepository;
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public GameService(IRepository<Game> repository, IMapper mapper, IRepository<Mechanic> mechanicRepository, IRepository<Genre> genreRepository)
        {
            _gameRepository = repository;
            _mapper = mapper;
            _mechanicRepository = mechanicRepository;
            _genreRepository = genreRepository;
        }

        public async Task<GameDto> CreateAsync(GameDto gameDto)
        {
            var game = _mapper.Map<Game>(gameDto);

            if (string.IsNullOrWhiteSpace(game.Name))
            {
                throw new InvalidNameException("Game name can't be empty.");
            }

            if (game.Name.Length < 4)
            {
                throw new InvalidNameException("Name lenght can't be less then 4");
            }

            game.Id = Guid.NewGuid();

            var genre = await _genreRepository.GetAsync(game.Genre.Id);

            if (genre is null)
            {
                throw new KeyNotFoundException($"Genre with id {game.Genre.Id} not exists.");
            }

            game.Genre = genre;

            var dbMechanics = await _mechanicRepository.GetAll().ToListAsync();

            var dbMechanicIds = dbMechanics.Select(m => m.Id);

            var gameMechanics = game.Mechanics;

            var gameMechanicIds = gameMechanics.Select(m => m.Id);

            var difference = gameMechanicIds.Where(t2 => !dbMechanicIds.Any(t1 => t2.Equals(t1)));

            if (difference.Any())
            {
                string ids = "";
                difference.ToList().ForEach(g => ids += g.ToString() + "\n");

                throw new KeyNotFoundException($"Mechanics with these ids not exists.\nIds:{ids}");
            }

            game.Mechanics = dbMechanics.Where(x => gameMechanicIds.Contains(x.Id)).ToList();

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
            var games = await _gameRepository.GetAllAsNoTracking()
                                             .Include(g => g.Genre)
                                             .Include(g => g.Mechanics)
                                             .AsSplitQuery()
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
