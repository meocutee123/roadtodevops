using Microsoft.EntityFrameworkCore;
using Nihongo.Entites.Nihongo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nihongo.Entites.Models
{
    public class Amenity : IEntity
    {
        public int Id { get; set; }
        public string Desciption { get; set; }
        [JsonIgnore]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
