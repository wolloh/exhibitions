using exhibitions.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibitions.Context.Entities
{
    public class Photo : BaseEntity
    {
        public byte[] PhotoBytes { get; set; }
        public int? ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
    }

}
