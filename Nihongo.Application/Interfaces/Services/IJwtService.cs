using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(Account account);
        string RandomTokenString(int length);
        void RemoveOldRefreshTokens(Account account);
        RefreshToken GenerateRefreshToken(string ipAddress);
        Task<(RefreshToken, Account)> GetRefreshToken(string token);
    }
}
