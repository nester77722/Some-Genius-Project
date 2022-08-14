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
    public class MechanicService : IMechanicService
    {
        private readonly IRepository<Mechanic> _repository;
        private readonly IMapper _mapper;

        public MechanicService(IMapper mapper, IRepository<Mechanic> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MechanicDto> CreateAsync(MechanicDto mechanicDto)
        {
            var mechanic = _mapper.Map<Mechanic>(mechanicDto);
            mechanic.Id = Guid.NewGuid();

            await _repository.CreateAsync(mechanic);

            var result = _mapper.Map<MechanicDto>(mechanic);

            return result;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MechanicDto>> GetAllAsync()
        {
            var mechanics = await _repository.GetAllAsNoTracking().ToListAsync();
            var result = _mapper.Map<List<MechanicDto>>(mechanics);

            return result;
        }

        public Task<MechanicDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MechanicDto> UpdateAsync(MechanicDto mechanicDto)
        {
            throw new NotImplementedException();
        }
    }
}
