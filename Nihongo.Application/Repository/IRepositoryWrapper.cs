using Nihongo.Application.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Repository
{
    public interface IRepositoryWrapper
    {
        IKanjiRepository Kanji { get; }
        Task SaveChangesAsync();
    }
}
