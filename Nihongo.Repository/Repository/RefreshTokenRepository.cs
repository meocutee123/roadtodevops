using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Repository
{
    public class RefreshTokenRepository : RepositoryBase<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(NihongoContext dbContext) : base(dbContext)
        {
        }
    }
}
