using AutoMapper;
using Nihongo.Application.Common.Requests;
using Nihongo.Application.Common.Responses;
using Nihongo.Entites.Models;
using Nihongo.Shared.Common.Requests;
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
            CreateMap<PropertyDto, Property>();

            CreateMap<AddPropertyRequest, Property>();

            CreateMap<Building, BuildingDto>();
            CreateMap<BuildingDto, Building>();

            CreateMap<Landlord, LandlordDto>();
            CreateMap<LandlordDto, Landlord>();

            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
        }
    }
}
