using System;
using Microsoft.AspNetCore.Identity;

namespace ChainStore.DataAccessLayer;

public class ApplicationUser : IdentityUser
{
    public Guid CustomerDbModelId { get; set; }
    public DateTimeOffset CreationTime { get; set; }
}