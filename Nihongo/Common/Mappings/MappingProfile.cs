using AutoMapper;
using Nihongo.Api.Commands.Kanji;
using Nihongo.Entites.Models;

namespace Nihongo.Api.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kanji, AddKanjiRequest>();
            CreateMap<AddKanjiRequest, Kanji>();
            CreateMap<UpdateKanjiRequest, Kanji>();
        }
    }
}
