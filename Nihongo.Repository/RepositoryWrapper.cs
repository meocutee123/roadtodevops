using Nihongo.Application.Interfaces;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using Nihongo.Repository.Repository;
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
        private IKanjiRepository _kanji;
        //private IUserRepository _user;
        private IRefreshTokenRepository _refreshToken;
        private IAccountRepository _accountRepository;

        public RepositoryWrapper(NihongoContext nihongoContext)
        {
            _dbContext = nihongoContext;
        }
        public IKanjiRepository Kanji
        {
            get
            {
                if (_kanji == null)
                {
                    _kanji = new KanjiRepository(_dbContext);
                }
                return _kanji;
            }
        }

        //public IUserRepository User {
        //    get
        //    {
        //        if (_user == null)
        //        {
        //            _user = new UserRepository(_dbContext);
        //        }
        //        return _user;
        //    }
        //}

        public IRefreshTokenRepository RefreshToken
        {
            get
            {
                if (_refreshToken == null)
                {
                    _refreshToken = new RefreshTokenRepository(_dbContext);
                }
                return _refreshToken;
            }
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

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
