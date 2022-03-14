using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using Nihongo.Shared.Interfaces.Services;
using Nihongo.Shared.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Services
{
    public class JwtService : IJwtService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly SharedAppSettings _appSettings;

        public JwtService(IRepositoryWrapper repository,
             IOptions<SharedAppSettings> appSettings)
        {
            _repository = repository;
            _appSettings = appSettings.Value;
        }

        public string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(35) + Guid.NewGuid(),
                Expires = DateTime.UtcNow.AddDays(10),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }
        public string RandomTokenString(int length)
        {
            var random = new Random();
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, length)
                .Select(x => x[random.Next(x.Length)])
                .ToArray()) + Guid.NewGuid();
        }
        public async Task<(RefreshToken, Account)> GetRefreshToken(string token)
        {
            var account = await _repository.Account.FindAsync(u => u.RefreshTokens.Any(t => t.Token == token));
            if (account == null) throw new UnauthorizedAccessException("Invalid token");

            var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive) throw new UnauthorizedAccessException("Invalid token");

            return (refreshToken, account);
        }

        public void RemoveOldRefreshTokens(Account account)
        {
            account.RefreshTokens.ToList().RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }
    }
}
