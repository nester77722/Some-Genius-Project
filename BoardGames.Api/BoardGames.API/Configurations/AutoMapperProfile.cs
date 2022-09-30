using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Services.Models;

namespace BoardGames.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GetGameDto>()
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(game => game.Image.ThumbnailData))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(game => game.Image.ImageData));
            CreateMap<Game, GetGameWithoutDetailsDto>()
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(game => game.Image.ThumbnailData))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(game => game.Image.ImageData));

            CreateMap<CreateGameDto, Game>().ForMember(dest => dest.Image, opt => opt.MapFrom(
                                                        gameDto => new Image
                                                        {
                                                            ImageData = gameDto.Image
                                                        })); ;
            CreateMap<GetGameDto, Game>().ForMember("Id", opt => opt.MapFrom(gameDto => gameDto.Id))
                                         .ForMember(dest => dest.Image, opt => opt.MapFrom(
                                                        gameDto => new Image
                                                        {
                                                            ImageData = gameDto.Image,
                                                            ThumbnailData = gameDto.Thumbnail
                                                        }));

            CreateMap<Mechanic, GetMechanicWithGamesDto>()
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(mechanic => mechanic.Image.ThumbnailData))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(mechanic => mechanic.Image.ImageData));
            CreateMap<Mechanic, GetMechanicWithoutGamesDto>()
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(mechanic => mechanic.Image.ThumbnailData))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(mechanic => mechanic.Image.ImageData));
            
            CreateMap<GetMechanicWithGamesDto, Mechanic>()
                .ForMember("Id", opt => opt.MapFrom(mechanicDto => mechanicDto.Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(
                                                        mechanicDto => new Image
                                                        {
                                                            ImageData = mechanicDto.Image,
                                                            ThumbnailData = mechanicDto.Thumbnail
                                                        }));

            CreateMap<CreateMechanicDto, Mechanic>().ForMember(dest => dest.Image, opt => opt.MapFrom(
                                                        mechanicDto => new Image
                                                        {
                                                            ImageData = mechanicDto.Image,
                                                        })); ;

            CreateMap<Genre, GetGenreWithGamesDto>().ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(genre => genre.Image.ThumbnailData))
                                                    .ForMember(dest => dest.Image, opt => opt.MapFrom(genre => genre.Image.ImageData));
            CreateMap<Genre, GetGenreWithoutGamesDto>().ForMember(dest => dest.Image, opt => opt.MapFrom(genre => genre.Image.ImageData))
                                                       .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(genre => genre.Image.ThumbnailData));

            CreateMap<GetGenreWithGamesDto, Genre>().ForMember("Id", opt => opt.MapFrom(genreDto => genreDto.Id))
                                                    .ForMember(dest => dest.Image, opt => opt.MapFrom(
                                                        genreDto => new Image
                                                        {
                                                            ImageData = genreDto.Image,
                                                            ThumbnailData = genreDto.Thumbnail
                                                        }));
            CreateMap<CreateGenreDto, Genre>().ForMember(dest => dest.Image, opt => opt.MapFrom(
                                                        genreDto => new Image
                                                        {
                                                            ImageData = genreDto.Image
                                                        }));


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
