using Nihongo.Application.Repository.Interfaces;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Repository
{
    public class KanjiRepository : RepositoryBase<Kanji>, IKanjiRepository
    {
        public KanjiRepository(NihongoContext dbContext) : base(dbContext)
        {
        }
    }
}
