using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Interfaces.Reposiroty
{
    public interface IRepositoryWrapper
    {
        IKanjiRepository Kanji { get; }
        IUserRepository User { get; }
        IRefreshTokenRepository RefreshToken { get; }
        Task SaveChangesAsync();
    }
}
