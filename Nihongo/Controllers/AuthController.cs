using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nihongo.Api.Filters;
using Nihongo.Api.Models;
using Nihongo.Application.Commands.Auth;
using Nihongo.Application.Common;
using Nihongo.Application.Common.Settings;
using Nihongo.Application.Dtos;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly JWTSettings _jwtSettings;

        public AuthController(IRepositoryWrapper repositoryWrapper,
            IOptions<JWTSettings> jwtSettings,
            IMapper mapper,
            TokenValidationParameters tokenValidationParameters)
        {
            this._repositoryWrapper = repositoryWrapper;
            this._mapper = mapper;
            this._tokenValidationParameters = tokenValidationParameters;
            this._jwtSettings = jwtSettings.Value;
        }
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidateFilterAttribute))]
        public async Task<AuthResult> Login([FromBody] AuthRequest request)
        {
            var user = await _repositoryWrapper.User.FindAsync(u => u.Username == request.Username);
            if (user != null)
            {
                return await GenerateToken(user);
            }
            return new AuthResult() 
            {
                Success = false,
                Token = null,
                RefreshToken = null,
                Errors = new List<string>() { "Username and password did not work!" }
            };
        }
        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidateFilterAttribute))]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var result = await VerifyAndGenerateToken(request);
            if (result == null)
            {
                return BadRequest(new AuthResult()
                {
                    Success = false,
                    Errors = new List<string> { "Invalid token" }
                });
            }
            return Ok(result);
        }
        private async Task<AuthResult> GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] {
                        new Claim("Id", user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, user.Username),
                        }),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = signingCredentials,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = new RefreshTokenDto()
            {
                JwtId = token.Id,
                IsUsed = false,
                IsRevork = false,
                UserId = user.Id,
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6),
                Token = RandomString(35) + Guid.NewGuid(),
            };

            await _repositoryWrapper.RefreshToken.AddAsync(_mapper.Map<RefreshToken>(refreshToken));
            await _repositoryWrapper.SaveChangesAsync();

            return new AuthResult()
            {
                Token = jwtToken,
                Success = true,
                Errors = new List<string>(),
                RefreshToken = refreshToken.Token
            };
        }
        private async Task<AuthResult> VerifyAndGenerateToken(TokenRequest request)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenInVerification = jwtTokenHandler.ValidateToken(request.Token, _tokenValidationParameters, out var validatedToken);

            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (!result) return null;
            }

            var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);

            if (expiryDate > DateTime.UtcNow)
            {
                return new AuthResult()
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Token has not yet expried"
                    },
                };
            }

            var storedToken = await _repositoryWrapper.RefreshToken.FindAsync(x => x.Token == request.Token);

            if (storedToken == null)
            {
                return new AuthResult()
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Token does not exist"
                    },
                };
            }

            if (storedToken.IsUsed)
            {
                return new AuthResult()
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Token has been used"
                    },
                };
            }

            if (storedToken.IsRevork)
            {
                return new AuthResult()
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Token has been revorked"
                    },
                };
            }

            var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            if (storedToken.JwtId != jti)
            {
                return new AuthResult()
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Token does not match"
                    },
                };
            }

            storedToken.IsUsed = true;
            await _repositoryWrapper.RefreshToken.UpdateAsync(storedToken);
            await _repositoryWrapper.SaveChangesAsync();

            var dbUser = await _repositoryWrapper.User.FindAsync(x => x.Id == storedToken.UserId);
            return await GenerateToken(dbUser);
        }
        private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTimeVal;
        }
        private string RandomString(int length)
        {
            var random = new Random();
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, length)
                .Select(x => x[random.Next(x.Length)])
                .ToArray());
        }
    }
}
