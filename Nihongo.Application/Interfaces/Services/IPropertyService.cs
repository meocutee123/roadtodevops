using Nihongo.Shared.Common.Requests;
using Nihongo.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.Interfaces.Services
{
    public interface IPropertyService
    {
        Task AddAsync(AddPropertyRequest request);
    }
}
