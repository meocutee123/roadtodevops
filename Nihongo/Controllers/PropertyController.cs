using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nihongo.Api.Extensions.Authorization;
using Nihongo.Api.Filters;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Enums;
using Nihongo.Entites.Models;
using Nihongo.Shared.Common.Requests;
using Nihongo.Shared.DTOs;
using Nihongo.Shared.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nihongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public PropertyController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [Authorize(Role.Employee, Role.Admin)]
        [HttpGet]
        public async Task<List<PropertyDto>> GetAll()
        {
            var properties = _mapper.Map<List<PropertyDto>>(await _repositoryWrapper.Property.GetAllPropertyAsync());
            return properties;
        }

        [Authorize(Role.Employee, Role.Admin)]
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsAttribute<Property>))]
        public async Task<PropertyDto> GetById(int id)
        {
            var property = _mapper.Map<PropertyDto>(await _repositoryWrapper.Property.GetByKeyAsync(key: id));
            return property;
        }

        [Authorize(Role.Employee, Role.Admin)]
        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttribute))]
        public async Task<IActionResult> Task(AddPropertyRequest request)
        {
            var images = _mapper.Map<List<Image>>(request.Images);

            var landLord = await _repositoryWrapper.Landlord.FindAsync(x => x.Id == request.LandlordId);
            var building = await _repositoryWrapper.Building.FindAsync(x => x.Id == request.BuildingId);

            if (building is null) throw new KeyNotFoundException("[Property / Controller] Buiding not found!");
            if (landLord is null) throw new KeyNotFoundException("[Property / Controller] Landlord not found!");

            var property = new Property
            {
                Type = request.Type,
                AdditionalInformation = request.AdditionalInformation,
                BathCount = request.BathCount,
                HighLights = request.Highlights,
                OtherFeatures = request.OtherFeatures,
                RoomCount = request.RoomCount,
                Landlord = landLord,
                Building = building,
                Images = images,
                CreatedBy = 4,
                Created = DateTime.UtcNow,
                Amenities = request.Amenities,
            };
            await _repositoryWrapper.Property.AddAsync(property);
            await _repositoryWrapper.SaveChangesAsync();

            return Ok();
        }
    }
}
