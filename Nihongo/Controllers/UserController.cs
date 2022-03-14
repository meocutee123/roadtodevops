using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nihongo.Api.Extensions.Authorization;
using Nihongo.Api.Filters;
using Nihongo.Application.Common.Responses;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Enums;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nihongo.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UserController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<List<AccountResponse>> GetAll()
        {
            var users = _mapper.Map<List<AccountResponse>>(await _repository.Account.GetAll().ToListAsync());
            return users;
        }

        [HttpGet("{id}", Name = "GetById")]
        [ServiceFilter(typeof(ValidateEntityExistsAttribute<Account>))]
        public async Task<AccountResponse> GetById()
        {
            return _mapper.Map<AccountResponse>(await Task.FromResult(HttpContext.Items["entity"] as Account));
        }

        [Authorize]
        [HttpGet("findByEmail")]
        public async Task<AccountResponse> Find(string emailAddress)
        {
            var user =  _mapper.Map<AccountResponse>(await _repository.Account.FindAsync(x => x.Email == emailAddress));
            if (user == null) throw new KeyNotFoundException($"Cannot find user with email: {emailAddress}");
            return user;
        }

        //[HttpPost]
        //[ServiceFilter(typeof(ValidateFilterAttribute))]
        //public async Task<CreatedAtRouteResult> Create([FromBody] AddKanjiRequest request)
        //{
        //    var entity = _mapper.Map<Kanji>(request);
        //    await _repository.Kanji.AddAsync(entity);
        //    await _repository.SaveChangesAsync();
        //    var Kanji = _mapper.Map<KanjiDto>(entity);
        //    return CreatedAtRoute("GetById", new { id = Kanji.Id }, Kanji);
        //}

        //[HttpPut]
        //[ServiceFilter(typeof(ValidateFilterAttribute))]
        //[ServiceFilter(typeof(ValidateEntityExistsAttribute<Kanji>))]
        //public async Task<NoContentResult> Update([FromBody] UpdateKanjiRequest request)
        //{
        //    var entity = _mapper.Map<Kanji>(request);
        //    await _repository.Kanji.UpdateAsync(entity);
        //    await _repository.SaveChangesAsync();
        //    return NoContent();
        //}

        [Authorize(Role.Admin)]
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsAttribute<Account>))]
        public async Task<NoContentResult> Delete(int id)
        {
            await _repository.Account.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
