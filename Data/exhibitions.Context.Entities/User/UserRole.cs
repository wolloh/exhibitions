using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibitions.Context.Entities.User
{
    public class UserRole : IdentityRole<Guid>
    {
    }
}
