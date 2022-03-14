using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nihongo.Application.Common;
using Nihongo.Application.Common.Requests;
using Nihongo.Application.Common.Responses;
using Nihongo.Application.Helpers;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Application.Interfaces.Services;
using Nihongo.Entites.Enums;
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
using BC = BCrypt.Net.BCrypt;

namespace Nihongo.Repository.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;

        public AccountService(IRepositoryWrapper repository,
             IJwtService jwtService,
             IMapper mapper,
             IEmailService emailService)
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var account = await _repository.Account.FindAsync(x => x.Email == model.Username);

            if (account == null /*|| !account.IsVerified*/ || !BC.Verify(model.Password, account.PasswordHash))
                throw new UnauthorizedAccessException("The logon attempt failed");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtService.GenerateJwtToken(account);
            var refreshToken = _jwtService.GenerateRefreshToken(ipAddress);
            account.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from account
            _jwtService.RemoveOldRefreshTokens(account);

            // save changes to db
            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;
            return response;
        }
        public async Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
        {
            var (refreshToken, account) = await _jwtService.GetRefreshToken(token);

            // replace old refresh token with a new one and save
            var newRefreshToken = _jwtService.GenerateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            account.RefreshTokens.Add(newRefreshToken);

            _jwtService.RemoveOldRefreshTokens(account);

            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();

            // generate new jwt
            var jwtToken = _jwtService.GenerateJwtToken(account);

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;
            return response;
        }
        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var account = await _repository.Account.FindAsync(x => x.Email == model.Email);

            // always return ok response to prevent email enumeration
            if (account == null) return;

            // create reset token that expires after 1 day
            account.ResetToken = _jwtService.RandomTokenString(35);
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();

            // send email
            //SendPasswordResetEmail(account, origin);
        }
        public async Task Register(RegisterRequest model, string origin)
        {
            var isExist = await _repository.Account.FindAsync(x => x.Email == model.Email);
            // validate
            if (isExist != null)
            {
                throw new AppException($"The email {model.Email} already exists");
                // send already registered error in email to prevent account enumeration
                //SendAlreadyRegisteredEmail(model.Email, origin);
                //return;
            }

            // map model to new account object
            var account = _mapper.Map<Account>(model);

            // first registered account is an admin
            var isFirstAccount = await _repository.Account.GetAll().AnyAsync();
            account.Role = !isFirstAccount ? Role.Admin: Role.Employee;
            account.Created = DateTime.UtcNow;
            account.VerificationToken = _jwtService.RandomTokenString(35);

            // hash password
            account.PasswordHash = BC.HashPassword(model.Password);

            // save account
            await _repository.Account.AddAsync(account);
            await _repository.SaveChangesAsync();

            // send email
            //SendVerificationEmail(account, origin);
        }
        public async Task VerifyEmail(string token)
        {
            var account = await _repository.Account.FindAsync(x => x.VerificationToken == token);

            if (account == null) throw new AppException("Verification failed");

            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();
        }
        public async Task RevokeToken(string token, string ipAddress)
        {
            var (refreshToken, account) = await _jwtService.GetRefreshToken(token);

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();
        }
        public async Task ResetPassword(ResetPasswordRequest model)
        {
            var account = await _repository.Account.FindAsync(x =>
                x.ResetToken == model.Token &&
                x.ResetTokenExpires > DateTime.UtcNow);

            if (account == null)
                throw new UnauthorizedAccessException("Invalid token");

            // update password and remove reset token
            account.PasswordHash = BC.HashPassword(model.Password);
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;

            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();
        }
        public async Task ValidateResetToken(ValidateResetTokenRequest model)
        {
            var account = await _repository.Account.FindAsync(x =>
                x.ResetToken == model.Token &&
                x.ResetTokenExpires > DateTime.UtcNow);

            if (account == null)
                throw new UnauthorizedAccessException("Invalid token");
        }
        public async Task<List<Account>> GetAll()
        {
            return await _repository.Account.GetAll().ToListAsync();
        }
    }

}
