using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nihongo.Entites.Models
{
    [Owned]
    public class PropertyOtherFeature
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Label { get; set; }
        public string FieldAlias { get; set; }
        public string Value { get; set; }
    }
}
