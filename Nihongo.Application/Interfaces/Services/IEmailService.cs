using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.Interfaces.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
        void SendVerificationEmail(Account account, string origin);
        void SendAlreadyRegisteredEmail(string email, string origin);
        void SendPasswordResetEmail(Account account, string origin);
    }
}
