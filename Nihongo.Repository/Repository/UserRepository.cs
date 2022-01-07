using Nihongo.Application.Commands.Auth;
using Nihongo.Application.Interfaces;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(NihongoContext dbContext) : base(dbContext)
        {
        }
    }
}
