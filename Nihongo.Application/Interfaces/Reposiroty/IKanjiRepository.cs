using Nihongo.Application.Commands.Kanji;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Interfaces.Reposiroty
{
    public interface IKanjiRepository : IRepositoryBase<Kanji>
    {
        Task<IEnumerable<Kanji>> GetAllKanjiAsync(GetAllKanjiPagingRequest request);
    }
}
