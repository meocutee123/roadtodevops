using Microsoft.EntityFrameworkCore;
using Nihongo.Application.Commands.Kanji;
using Nihongo.Application.Interfaces.Reposiroty;
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

        public async Task<IEnumerable<Kanji>> GetAllKanjiAsync(GetAllKanjiPagingRequest request)
        {
            return await GetAllAsync().OrderBy(k => k.Romanization)
                .Skip((request.PageIndex) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
        }
    }
}
