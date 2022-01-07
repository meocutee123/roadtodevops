using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nihongo.Api.Filters;
using Nihongo.Application.Commands.Kanji;
using Nihongo.Application.Dtos;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using RoadToDevops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nihongo.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class KanjiController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public KanjiController(IRepositoryWrapper repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<List<KanjiDto>> Get([FromQuery] GetAllKanjiPagingRequest request)
        {
            var Kanji = _mapper.Map<List<KanjiDto>>(await _repository.Kanji.GetAllKanjiAsync(request));
            return Kanji;
        }

        [HttpGet("{id}", Name = "GetById")]
        [ServiceFilter(typeof(ValidateEntityExistsAttribute<Kanji>))]
        public async Task<KanjiDto> GetById(int id)
        {
            return _mapper.Map<KanjiDto>(await Task.FromResult(HttpContext.Items["entity"] as Kanji));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateFilterAttribute))]
        public async Task<CreatedAtRouteResult> Create([FromBody] AddKanjiRequest request)
        {
            var entity = _mapper.Map<Kanji>(request);
            await _repository.Kanji.AddAsync(entity);
            await _repository.SaveChangesAsync();
            var Kanji = _mapper.Map<KanjiDto>(entity);
            return CreatedAtRoute("GetById", new { id = Kanji.Id }, Kanji);
        }
        [HttpPut]
        [ServiceFilter(typeof(ValidateFilterAttribute))]
        [ServiceFilter(typeof(ValidateEntityExistsAttribute<Kanji>))]
        public async Task<NoContentResult> Update([FromBody] UpdateKanjiRequest request)
        {
            var entity = _mapper.Map<Kanji>(request);
            await _repository.Kanji.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsAttribute<Kanji>))]
        public async Task<NoContentResult> Delete(int id)
        {
            await _repository.Kanji.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
