using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Helpers;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using BoardGames.Shared.Exceptions.MechanicServiceExceptions;
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

        public async Task<GetMechanicWithGamesDto> CreateAsync(CreateMechanicDto mechanicDto)
        {
            var mechanic = _mapper.Map<Mechanic>(mechanicDto);

            if (string.IsNullOrWhiteSpace(mechanic.Name))
            {
                throw new InvalidNameException("Mechanic name can't be empty.");
            }

            if (mechanic.Name.Length < 4)
            {
                throw new InvalidNameException("Mechanic name's lenght can't be less then 4");
            }

            mechanic.Id = Guid.NewGuid();

            if (mechanic.Image.ImageData is not null)
            {
                mechanic.Image.ThumbnailData = ImageHelper.CreateThumbnail(mechanic.Image.ImageData);
            }
            else
            {
                var imageByte = await ImageHelper.DefaultImage();
                var image = new Image
                {
                    ImageData = imageByte,
                    ThumbnailData = ImageHelper.CreateThumbnail(imageByte)
                };

                mechanic.Image = image;
            }

            await _repository.CreateAsync(mechanic);

            var result = _mapper.Map<GetMechanicWithGamesDto>(mechanic);

            return result;
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetMechanicWithGamesDto>> GetAllAsync()
        {
            var mechanics = await _repository.GetAllAsNoTracking().ToListAsync();
            var result = _mapper.Map<List<GetMechanicWithGamesDto>>(mechanics);

            return result;
        }

        public async Task<List<GetMechanicWithoutGamesDto>> GetAllWithoutGamesAsync()
        {
            var mechanics = await _repository.GetAllAsNoTracking().ToListAsync();
            var result = _mapper.Map<List<GetMechanicWithoutGamesDto>>(mechanics);

            return result;
        }

        public async Task<GetMechanicWithGamesDto> GetAsync(string id)
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

            var result = _mapper.Map<GetMechanicWithGamesDto>(mechanic);

            return result;
        }

        public Task<GetMechanicWithGamesDto> UpdateAsync(GetMechanicWithGamesDto mechanicDto)
        {
            throw new NotImplementedException();
        }
    }
}
