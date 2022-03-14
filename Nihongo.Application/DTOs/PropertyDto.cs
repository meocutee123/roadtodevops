using Nihongo.Entites.Enums;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.DTOs
{
    public class PropertyDto
    {
        public BuildingDto Building { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }
        public PropertyType Type { get; set; }
        public List<OtherFeature> OtherFeatures { get; set; }
        public string Highlights { get; set; }
        public List<AmenityDto> Amenities { get; set; }
        public List<ImageDto> Images { get; set; }
        public List<PropertyAdditionalInformation> AdditionalInformation { get; set; }
        public LandlordDto Landlord { get; set; }
    }
}
