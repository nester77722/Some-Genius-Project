using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Services.Models;

namespace BoardGames.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>().ForMember("Id", opt => opt.MapFrom(gameDto => gameDto.Id));

            CreateMap<Mechanic, MechanicDto>();
            CreateMap<MechanicDto, Mechanic>().ForMember("Id", opt => opt.MapFrom(mechanicDto => mechanicDto.Id));

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>().ForMember("Id", opt => opt.MapFrom(genreDto => genreDto.Id));
 

            CreateMap<string, Guid>().ConvertUsing(s => Guid.Parse(s));
            CreateMap<string, Guid?>().ConvertUsing(s => string.IsNullOrWhiteSpace(s) ? null : Guid.Parse(s));
            CreateMap<Guid, string>().ConvertUsing(g => g.ToString("N"));

            CreateMap<String, Guid>().ConvertUsing(s => MapGuid(s));
        }

        private Guid MapGuid(string guidString)
        {
            var guid = Guid.Empty;
            Guid.TryParse(guidString, out guid);
            return guid;
        }
    }
}
