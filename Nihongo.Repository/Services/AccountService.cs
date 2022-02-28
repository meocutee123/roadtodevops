using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nihongo.Application.Common;
using Nihongo.Application.Common.Requests;
using Nihongo.Application.Common.Responses;
using Nihongo.Application.Helpers;
using Nihongo.Application.Helpers.Exceptions;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Application.Interfaces.Services;
using Nihongo.Entites.Models;
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
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public AccountService(IRepositoryWrapper repository,
             IOptions<AppSettings> appSettings,
             IMapper mapper,
             IEmailService emailService)
        {
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var account = await _repository.Account.FindAsync(x => x.Email == model.Username);

            if (account == null /*|| !account.IsVerified*/ || !BC.Verify(model.Password, account.PasswordHash))
                throw new UnauthorizedAccessException("The logon attempt failed");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = GenerateJwtToken(account);
            var refreshToken = GenerateRefreshToken(ipAddress);
            account.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from account
            RemoveOldRefreshTokens(account);

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
            var (refreshToken, account) = await GetRefreshToken(token);

            // replace old refresh token with a new one and save
            var newRefreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            account.RefreshTokens.Add(newRefreshToken);

            RemoveOldRefreshTokens(account);

            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();

            // generate new jwt
            var jwtToken = GenerateJwtToken(account);

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
            account.ResetToken = RandomTokenString(35);
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            await _repository.Account.UpdateAsync(account);
            await _repository.SaveChangesAsync();

            // send email
            SendPasswordResetEmail(account, origin);
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
            account.VerificationToken = RandomTokenString(35);

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
            var (refreshToken, account) = await GetRefreshToken(token);

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
        private string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private static RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(35) + Guid.NewGuid(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }
        private static string RandomTokenString(int length)
        {
            var random = new Random();
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, length)
                .Select(x => x[random.Next(x.Length)])
                .ToArray()) + Guid.NewGuid();
        }
        private void RemoveOldRefreshTokens(Account account)
        {
            account.RefreshTokens.ToList().RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }
        private void SendVerificationEmail(Account account, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/account/verify-email?token={account.VerificationToken}";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to verify your email address with the <code>/accounts/verify-email</code> api route:</p>
                             <p><code>{account.VerificationToken}</code></p>";
            }

            _emailService.Send(
                to: account.Email,
                subject: "Sign-up Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}"
            );
        }
        private void SendAlreadyRegisteredEmail(string email, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
                message = $@"<p>If you don't know your password please visit the <a href=""{origin}/account/forgot-password"">forgot password</a> page.</p>";
            else
                message = "<p>If you don't know your password you can reset it via the <code>/accounts/forgot-password</code> api route.</p>";

            _emailService.Send(
                to: email,
                subject: "Sign-up Verification API - Email Already Registered",
                html: $@"<h4>Email Already Registered</h4>
                         <p>Your email <strong>{email}</strong> is already registered.</p>
                         {message}"
            );
        }
        private void SendPasswordResetEmail(Account account, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var resetUrl = $"{origin}/account/reset-password?token={account.ResetToken}";
                message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to reset your password with the <code>/accounts/reset-password</code> api route:</p>
                             <p><code>{account.ResetToken}</code></p>";
            }

            _emailService.Send(
                to: account.Email,
                subject: "Sign-up Verification API - Reset Password",
                html: $@"<h4>Reset Password Email</h4>
                         {message}"
            );
        }
        private async Task<(RefreshToken, Account)> GetRefreshToken(string token)
        {
            var account = await _repository.Account.FindAsync(u => u.RefreshTokens.Any(t => t.Token == token));
            if (account == null) throw new UnauthorizedAccessException ("Invalid token");

            var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive) throw new UnauthorizedAccessException ("Invalid token");

            return (refreshToken, account);
        }

        public async Task<List<Account>> GetAll()
        {
            return await _repository.Account.GetAll().ToListAsync();
        }
    }
}
