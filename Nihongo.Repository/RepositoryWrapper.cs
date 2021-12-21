using Nihongo.Application.Repository;
using Nihongo.Application.Repository.Interfaces;
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
        private NihongoContext _dbContext;
        private IKanjiRepository _kanji;

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

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
