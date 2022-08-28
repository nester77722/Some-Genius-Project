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

        public async Task<GenreDto> CreateAsync(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            genre.Id = Guid.NewGuid();

            await _repository.CreateAsync(genre);

            var result = _mapper.Map<GenreDto>(genre);

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

        public async Task<List<GenreDto>> GetAllAsync()
        {
            var genres = await _repository.GetAllAsNoTracking()
                                          .ToListAsync();

            var result = _mapper.Map<List<GenreDto>>(genres);

            return result;
        }

        public async Task<GenreDto> GetAsync(string id)
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

            var result = _mapper.Map<GenreDto>(genre);

            return result;
        }

        public Task<GenreDto> UpdateAsync(GenreDto genreDto)
        {
            throw new NotImplementedException();
        }
    }
}
