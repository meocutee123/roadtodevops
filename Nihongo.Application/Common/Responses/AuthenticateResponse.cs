using Nihongo.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nihongo.Application.Common.Responses
{
    public class AuthenticateResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        //public AuthenticateResponse(Account user, string token)
        //{
        //    Id = user.Id;
        //    FirstName = user.FirstName;
        //    LastName = user.LastName;
        //    Role = user.Role;
        //    JwtToken = token;
        //}
    }
}
