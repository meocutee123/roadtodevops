using Nihongo.Entites.Enums;
using Nihongo.Entites.Nihongo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

#nullable disable

namespace Nihongo.Entites.Models
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public AccountType Type { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public virtual ICollection<Property> PropertiesCreatedBy { get; set; }
        public virtual ICollection<Property> PropertiesModifiedBy { get; set; }
        public virtual ICollection<Building> BuildingsCreatedBy { get; set; }
        public virtual ICollection<Building> BuildingsModifiedBy { get; set; }
        public virtual ICollection<Landlord> LandlordsCreatedBy { get; set; }
        public virtual ICollection<Landlord> LandlordsModifiedBy { get; set; }

        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
