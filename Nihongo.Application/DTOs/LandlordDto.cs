using Nihongo.Entites.Enums;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.DTOs
{
    public class LandlordDto
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public PreferredContactMethod PreferredContactMethod { get; set; }

        public List<LandlordOtherDetail> LandlordOtherDetail { get; set; }
    }
}
