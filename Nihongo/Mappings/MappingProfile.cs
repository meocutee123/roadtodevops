using AutoMapper;
using Nihongo.Application.Common.Requests;
using Nihongo.Application.Common.Responses;
using Nihongo.Entites.Models;
using Nihongo.Shared.DTOs;

namespace Nihongo.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountResponse>();
            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();

            CreateMap<Property, PropertyDto>();
            CreateMap<Building, BuildingDto>();
            CreateMap<Landlord, LandlordDto>();
            CreateMap<Amenity, AmenityDto>();
            CreateMap<ImageDto, ImageDto>();
        }
    }
}
