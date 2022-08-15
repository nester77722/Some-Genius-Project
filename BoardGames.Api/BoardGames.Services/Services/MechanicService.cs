using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<MechanicDto> GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            Guid mechanicId;

            if (!Guid.TryParse(id, out mechanicId))
            {
                return null;
            }

            var mechanic = await _repository.GetAsync(mechanicId,
                                                      include => include.Games);

            if (mechanic is null)
            {
                return null;
            }

            var result = _mapper.Map<MechanicDto>(mechanic);

            return result;
        }

        public Task<MechanicDto> UpdateAsync(MechanicDto mechanicDto)
        {
            throw new NotImplementedException();
        }
    }
}
