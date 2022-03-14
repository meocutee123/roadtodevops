using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using Nihongo.Shared.DTOs;
using System.Collections.Generic;
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
        [HttpGet]
        public async Task<PropertyDto> GetAll()
        {
            var properties = _mapper.Map<PropertyDto>(await _repositoryWrapper.Property.GetAllPropertyAsync());
            return properties;
        }

        [HttpGet("{id}")]
        public async Task<Property> GetById(int id)
        {
            var users = await _repositoryWrapper.Property.FindAsync(x => x.Id.Equals(id));
            return users;
        }
    }
}
