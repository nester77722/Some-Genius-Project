using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using BoardGames.Shared.Exceptions.GenreServiceExceptions;
using Microsoft.EntityFrameworkCore;

namespace BoardGames.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public GenreService(IMapper mapper, IRepository<Genre> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetGenreWithGamesDto> CreateAsync(CreateGenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);

            if (string.IsNullOrWhiteSpace(genre.Name))
            {
                throw new InvalidNameException("Genre name can't be empty.");
            }

            if (genre.Name.Length < 4)
            {
                throw new InvalidNameException("Genre name's lenght can't be less then 4");
            }

            genre.Id = Guid.NewGuid();

            await _repository.CreateAsync(genre);

            var result = _mapper.Map<GetGenreWithGamesDto>(genre);

            return result;
        }

        public async Task DeleteAsync(string id)
        {
            Guid guid;
            var isGuid = Guid.TryParse(id, out guid);

            if (!isGuid)
            {
                throw new InvalidIdException("Invalid genre id");
            }

            var genre = await _repository.GetAsync(guid);

            if (genre is null)
            {
                throw new InvalidIdException($"There isn't any genre with id {id}");
            }

            await _repository.DeleteAsync(genre);

        }

        public async Task<List<GetGenreWithGamesDto>> GetAllAsync()
        {
            var genres = await _repository.GetAllAsNoTracking()
                                          .ToListAsync();

            var result = _mapper.Map<List<GetGenreWithGamesDto>>(genres);

            return result;
        }

        public async Task<List<GetGenreWithoutGamesDto>> GetAllWithoutGamesAsync()
        {
            var genres = await _repository.GetAllAsNoTracking()
                                          .ToListAsync();

            var result = _mapper.Map<List<GetGenreWithoutGamesDto>>(genres);

            return result;
        }

        public async Task<GetGenreWithGamesDto> GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            Guid genreId;

            if (!Guid.TryParse(id, out genreId))
            {
                return null;
            }

            var genre = await _repository.GetAsync(genreId,
                                                      include => include.Games);

            if (genre is null)
            {
                return null;
            }

            var result = _mapper.Map<GetGenreWithGamesDto>(genre);

            return result;
        }

        public Task<GetGenreWithGamesDto> UpdateAsync(GetGenreWithGamesDto genreDto)
        {
            throw new NotImplementedException();
        }
    }
}
