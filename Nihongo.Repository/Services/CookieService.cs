using Microsoft.AspNetCore.Http;
using Nihongo.Entites.Models;
using Nihongo.Shared.Exceptions;
using Nihongo.Shared.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Services
{
    public class CookieService : ICookieService
    {
        private readonly HttpContext _httpContext;
        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        public Account ActiveAccount()
        {
            var account = _httpContext.Items["Account"] as Account;

            return account;
        }
    }
}
