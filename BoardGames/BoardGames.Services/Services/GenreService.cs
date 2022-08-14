using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GenreDto>> GetAllAsync()
        {
            var genres = await _repository.GetAllAsNoTracking().ToListAsync();

            var result = _mapper.Map<List<GenreDto>>(genres);

            return result;
        }

        public Task<GenreDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<GenreDto> UpdateAsync(GenreDto genreDto)
        {
            throw new NotImplementedException();
        }
    }
}
