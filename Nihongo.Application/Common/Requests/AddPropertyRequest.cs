using Nihongo.Entites.Enums;
using Nihongo.Entites.Models;
using Nihongo.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Shared.Common.Requests
{
    public class AddPropertyRequest
    {
        [Required]
        public int BuildingId { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        [Required]
        public PropertyType Type { get; set; }
        public List<PropertyOtherFeature> OtherFeatures { get; set; }
        [Required]
        public string Highlights { get; set; }
        public List<PropertyAmenity> Amenities { get; set; }
        [Required]
        public List<ImageDto> Images { get; set; }
        public List<PropertyAdditionalInformation> AdditionalInformation { get; set; }
        [Required]
        public int LandlordId { get; set; }
    }
}
