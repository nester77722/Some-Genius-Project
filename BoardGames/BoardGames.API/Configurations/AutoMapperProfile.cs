using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Services.Models;

namespace BoardGames.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GameDto>().ForMember("GenreName", opt => opt.MapFrom(game => game.Genre.Name))
                                      .ForMember("MechanicNames", opt => opt.MapFrom(game => game.Mechanics.Select(m => m.Name)))
                                      .ForMember("MechanicIds", opt => opt.MapFrom(game => game.Mechanics.Select(m => m.Id)));
            CreateMap<GameDto, Game>().ForMember("Id", opt => opt.MapFrom(gameDto => gameDto.Id));
            //CreateMap<GameDto, Game>();

            CreateMap<Mechanic, MechanicDto>();
            CreateMap<MechanicDto, Mechanic>().ForMember("Id", opt => opt.MapFrom(mechanicDto => mechanicDto.Id));
            //CreateMap<MechanicDto, Mechanic>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>().ForMember("Id", opt => opt.MapFrom(genreDto => genreDto.Id));
            //CreateMap<GenreDto, Genre>();

            CreateMap<string, Guid>().ConvertUsing(s => Guid.Parse(s));
            CreateMap<string, Guid?>().ConvertUsing(s => string.IsNullOrWhiteSpace(s) ? (Guid?)null : Guid.Parse(s));
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
