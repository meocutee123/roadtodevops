using Nihongo.Entites.Nihongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nihongo.Entites.Models
{
    public class Building : IEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int BuildingAge { get; set; }
        [JsonIgnore]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
