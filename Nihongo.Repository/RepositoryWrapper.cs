using Nihongo.Application.Interfaces;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using Nihongo.Repository.Repository;
using Nihongo.Shared.Interfaces.Reposiroty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly NihongoContext _dbContext;
        private IPropertyRepository _propertyRepository;
        private IAccountRepository _accountRepository;

        public RepositoryWrapper(NihongoContext nihongoContext)
        {
            _dbContext = nihongoContext;
        }

        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_dbContext);
                }
                return _accountRepository;
            }
        }
        public IPropertyRepository Property
        {
            get
            {
                if (_accountRepository == null)
                {
                    _propertyRepository = new PropertyRepository(_dbContext);
                }
                return _propertyRepository;
            }
        }
        
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
