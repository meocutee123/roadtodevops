using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.Interfaces.Reposiroty
{
    public interface IPropertyRepository : IRepositoryBase<Property>
    {
        Task<List<Property>> GetAllPropertyAsync();
        Task<Property> GetByKeyAsync(int key);
    }
}
