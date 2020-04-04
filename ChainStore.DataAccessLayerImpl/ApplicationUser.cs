using System;
using Microsoft.AspNetCore.Identity;

namespace ChainStore.DataAccessLayerImpl
{
    public class ApplicationUser : IdentityUser
    {
        public Guid ClientDbModelId { get; set; }
        public DateTimeOffset CreationTime { get; set; }
    }
}
