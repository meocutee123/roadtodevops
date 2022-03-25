using Nihongo.Entites.Enums;
using Nihongo.Entites.Nihongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nihongo.Entites.Models
{
    public class Property : AuditableEntity, IEntity
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        public string HighLights { get; set; }
        public PropertyType Type { get; set; }
        
        public List<PropertyOtherFeature> OtherFeatures { get; set; }
        public List<PropertyAdditionalInformation> AdditionalInformation { get; set; }
        public List<PropertyAmenity> Amenities { get; set; }
   
        public virtual ICollection<Image> Images { get; set; }
        public virtual Landlord Landlord { get; set; }
        public virtual Building Building { get; set; }

    }
}
