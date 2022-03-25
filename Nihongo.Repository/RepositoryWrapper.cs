using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nihongo.Application.Helpers;
using Nihongo.Application.Interfaces;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using Nihongo.Entites.Nihongo;
using Nihongo.Repository.Repository;
using Nihongo.Shared.Interfaces.Reposiroty;
using Nihongo.Shared.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nihongo.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly NihongoContext _dbContext;
        private IPropertyRepository _propertyRepository;
        private IAccountRepository _accountRepository;
        private IBuildingRepository _buildingRepository;
        private ILandlordRepository _landlordRepository;
        private readonly ICookieService _cookieService;
        public RepositoryWrapper(NihongoContext nihongoContext, ICookieService cookieService)
        {
            _dbContext = nihongoContext;
            _cookieService = cookieService;
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
        public IBuildingRepository Building
        {
            get
            {
                if (_buildingRepository is null) _buildingRepository = new BuildingRepository(_dbContext);
                return _buildingRepository;
            }
        }
        public ILandlordRepository Landlord
        {
            get
            {
                if (_landlordRepository is null) _landlordRepository = new LandlordRepository(_dbContext);
                return _landlordRepository;
            }
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added: 
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _cookieService.ActiveAccount().Id;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = _cookieService.ActiveAccount().Id;
                        break;
                }
            }
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
