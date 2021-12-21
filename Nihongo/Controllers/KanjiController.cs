using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nihongo.Api.Commands.Kanji;
using Nihongo.Application.Repository;
using Nihongo.Entites.Models;
using RoadToDevops;
using RoadToDevops.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nihongo.Api.Controllers
{
    [ApiController]
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
        public async Task<PagedResult<Kanji>> Get([FromQuery] GetAllKanjiPagingRequest request)
        {
            var Kanji = await _repository.Kanji.GetAllAsync();
            return new PagedResult<Kanji>() { Data = Kanji, TotalRecord = Kanji.Count, Code = 200 };
        }
        [HttpGet("{id}")]
        public async Task<PagedResult<Kanji>> GetById(int id)
        {
            var Kanji = await _repository.Kanji.GetByConditionAsync(k => k.Id == id);
            return new PagedResult<Kanji>() { Data = Kanji, TotalRecord = Kanji.Count, Code = 200 };
        }
        [HttpPost]
        public async Task<PagedResult<Kanji>> Create([FromBody] AddKanjiRequest request)
        {
            var entity = _mapper.Map<Kanji>(request);
            var response = await _repository.Kanji.AddAsync(entity);
            return new PagedResult<Kanji>() { Data = new List<Kanji>() { response }, Code = 200 };
        }
        [HttpPut]
        public async Task<PagedResult<Kanji>> Update([FromBody] UpdateKanjiRequest request)
        {
            var entity = _mapper.Map<Kanji>(request);
            await _repository.Kanji.UpdateAsync(entity);
            return new PagedResult<Kanji>() { Message = "Update successfully", Code = 200 };
        }
        [HttpDelete("{id}")]
        public async Task<PagedResult<Kanji>> Delete(int id)
        {
            await _repository.Kanji.DeleteAsync(id);
            return new PagedResult<Kanji>() { Message = "Delete successfully", Code = 200 };
        }
    }
}
