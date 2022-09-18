using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Services.Models;

namespace BoardGames.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GetGameDto>();
            CreateMap<Game, GetGameWithoutDetails>();
            CreateMap<CreateGameDto, Game>();
            CreateMap<GetGameDto, Game>().ForMember("Id", opt => opt.MapFrom(gameDto => gameDto.Id));

            CreateMap<Mechanic, GetMechanicWithGamesDto>();
            CreateMap<Mechanic, GetMechanicWithoutGamesDto>();
            CreateMap<GetMechanicWithGamesDto, Mechanic>().ForMember("Id", opt => opt.MapFrom(mechanicDto => mechanicDto.Id));
            CreateMap<CreateMechanicDto, Mechanic>();

            CreateMap<Genre, GetGenreWithGamesDto>();
            CreateMap<Genre, GetGenreWithoutGamesDto>();
            CreateMap<GetGenreWithGamesDto, Genre>().ForMember("Id", opt => opt.MapFrom(genreDto => genreDto.Id));
            CreateMap<CreateGenreDto, Genre>();


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
