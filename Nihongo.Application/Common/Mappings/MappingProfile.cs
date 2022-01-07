using AutoMapper;
using Nihongo.Application.Commands.Kanji;
using Nihongo.Application.Dtos;
using Nihongo.Entites.Models;

namespace Nihongo.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kanji, KanjiDto>();
            CreateMap<KanjiDto, Kanji>();
            CreateMap<Kanji, AddKanjiRequest>();
            CreateMap<AddKanjiRequest, Kanji>();
            CreateMap<UpdateKanjiRequest, Kanji>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<RefreshToken, RefreshTokenDto>();
            CreateMap<RefreshTokenDto, RefreshToken>();
        }
    }
}
