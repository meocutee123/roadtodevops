using Nihongo.Entites.Models;
using Nihongo.Shared.Interfaces.Reposiroty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Repository
{
    public class LandlordRepository : RepositoryBase<Landlord>, ILandlordRepository
    {
        public LandlordRepository(NihongoContext dbContext) : base(dbContext)
        {
        }
    }
}
