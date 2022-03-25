using AutoMapper;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using Nihongo.Shared.Common.Requests;
using Nihongo.Shared.DTOs;
using Nihongo.Shared.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public PropertyService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task AddAsync(AddPropertyRequest request)
        {

        }
    }
}
