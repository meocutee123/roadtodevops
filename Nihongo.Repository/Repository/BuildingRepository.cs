using Nihongo.Entites.Models;
using Nihongo.Shared.Interfaces.Reposiroty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Repository
{
    public class BuildingRepository : RepositoryBase<Building>, IBuildingRepository
    {
        public BuildingRepository(NihongoContext dbContext) : base(dbContext)
        {
        }
    }
}
