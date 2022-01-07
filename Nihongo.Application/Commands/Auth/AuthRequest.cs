using System.ComponentModel.DataAnnotations;

namespace Nihongo.Application.Commands.Auth
{
    public class AuthRequest
    {
        [Required]
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters!")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
