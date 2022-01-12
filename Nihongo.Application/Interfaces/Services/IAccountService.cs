using Nihongo.Application.Common.Requests;
using Nihongo.Application.Common.Responses;
using System.Threading.Tasks;

namespace Nihongo.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress);
        Task<AuthenticateResponse> RefreshTokenAsync(string token, string ipAddress);
        Task RevokeToken(string token, string ipAddress);
        Task Register(RegisterRequest model, string origin);
        Task VerifyEmail(string token);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task ValidateResetToken(ValidateResetTokenRequest model);
        Task ResetPassword(ResetPasswordRequest model);
        //IEnumerable<AccountResponse> GetAll();
        //AccountResponse GetById(int id);
        //AccountResponse Create(CreateRequest model);
        //AccountResponse Update(int id, UpdateRequest model);
        //void Delete(int id);
    }
}
