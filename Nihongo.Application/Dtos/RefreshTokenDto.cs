using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Dtos
{
    public class RefreshTokenDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsUsed { get; set; }
        public string JwtId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Token { get; set; }
        public bool IsRevork { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserDto User { get; set; }
    }
}
