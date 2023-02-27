using exhibitions.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibitions.Context.Entities
{
    public class Comment:BaseEntity
    {
        public string Message { get; set; }
        public DateTime Time_Published { get; set; }
        public int? ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public Guid? AuthorId { get; set; }
        public virtual User.User Author { get; set; }
    }
}
