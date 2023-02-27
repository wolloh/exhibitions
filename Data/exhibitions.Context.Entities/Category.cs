using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exhibitions.Context.Entities.Common;

namespace exhibitions.Context.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Exhibition> Exhibitions{ get; set; }
    }
}
