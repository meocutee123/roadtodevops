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
        public int Id { get; set; }
        public BuildingDto Building { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        public PropertyType Type { get; set; }
        public List<PropertyOtherFeature> OtherFeatures { get; set; }
        public string Highlights { get; set; }
        public List<PropertyAmenity> Amenities { get; set; }
        public List<ImageDto> Images { get; set; }
        public List<PropertyAdditionalInformation> AdditionalInformation { get; set; }
        public LandlordDto Landlord { get; set; }
    }
}
