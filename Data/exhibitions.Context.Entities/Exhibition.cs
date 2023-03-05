using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exhibitions.Context.Entities.Common;
using exhibitions.Context.Entities.User;
namespace exhibitions.Context.Entities
{
    public class Exhibition : BaseEntity
    {
        public string Name;
        public string Place;
        public DateTime Date;
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<User.User> Subscribed_Users { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
