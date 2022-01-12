using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Common.Requests
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
