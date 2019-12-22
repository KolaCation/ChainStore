using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ChainStore.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public Guid ClientId{ get; set; }
        public DateTimeOffset CreationTime { get; set; }
    }
}
