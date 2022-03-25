using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Entites.Nihongo
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }

        public virtual Account CreatedByAccount { get; set; }
        public virtual Account ModifiedByAccount { get; set; }
    }
}
