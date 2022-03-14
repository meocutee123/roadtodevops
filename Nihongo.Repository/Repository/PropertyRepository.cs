using Microsoft.EntityFrameworkCore;
using Nihongo.Entites.Models;
using Nihongo.Shared.Interfaces.Reposiroty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Repository
{
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        private readonly NihongoContext _dbContext;
        
        public PropertyRepository(NihongoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Property> GetAllPropertyAsync()
        {
            return await _dbContext.Properties
                .Include(p => p.Building)
                .Include(p => p.Landlord)
                .Include(p => p.Amenities)
                .Include(p => p.Images)
                .FirstOrDefaultAsync();
        }
    }
}
