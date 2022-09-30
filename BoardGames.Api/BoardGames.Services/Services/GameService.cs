using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Helpers;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using BoardGames.Shared.Exceptions.GameServiceExceptions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<GetGameDto> CreateAsync(CreateGameDto gameDto)
        {
            var game = new Game() { Name = gameDto.Name };

            if (string.IsNullOrWhiteSpace(game.Name))
            {
                throw new InvalidNameException("Game name can't be empty.");
            }

            if (game.Name.Length < 4)
            {
                throw new InvalidNameException("Game name's lenght can't be less then 4");
            }

            game.Id = Guid.NewGuid();

            var genre = await _genreRepository.GetAsync(gameDto.GenreId);

            if (genre is null)
            {
                throw new InvalidGenreException($"Genre with id {gameDto.GenreId} not exists.");
            }

            game.Genre = genre;

            var dbMechanics = await _mechanicRepository.GetAll().ToListAsync();

            var dbMechanicIds = dbMechanics.Select(m => m.Id);

            var gameMechanics = game.Mechanics;

            var gameMechanicIds = gameDto.MechanicIds;

            var difference = gameMechanicIds.Where(t2 => !dbMechanicIds.Any(t1 => t2.Equals(t1)));

            if (difference.Any())
            {
                string ids = "";
                difference.ToList().ForEach(g => ids += g.ToString() + "\n");

                throw new InvalidMechanicException($"Mechanics with these ids not exists.\nIds:{ids}");
            }

            game.Mechanics = dbMechanics.Where(x => gameMechanicIds.Contains(x.Id)).ToList();

            if (game.Image.ImageData is not null)
            {
                game.Image.ThumbnailData = ImageHelper.CreateThumbnail(game.Image.ImageData);
            }
            else
            {
                var imageByte = await ImageHelper.DefaultImage();
                var image = new Image
                {
                    ImageData = imageByte,
                    ThumbnailData = ImageHelper.CreateThumbnail(imageByte)
                };

                game.Image = image;
            }

            await _gameRepository.CreateAsync(game);

            var result = _mapper.Map<GetGameDto>(game);

            return result;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetGameWithoutDetailsDto>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsNoTracking()
                                             .Include(g => g.Genre)
                                             .Include(g => g.Mechanics)
                                             .AsSplitQuery()
                                             .ToListAsync();

            var result = _mapper.Map<List<GetGameWithoutDetailsDto>>(games);

            return result;
        }

        public async Task<GetGameDto> GetAsync(string id)
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

            var result = _mapper.Map<GetGameDto>(game);

            return result;
        }

        public Task<GetGameDto> UpdateAsync(GetGameDto gameDto)
        {
            throw new NotImplementedException();
        }
    }
}
