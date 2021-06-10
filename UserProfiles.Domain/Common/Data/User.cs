using Microsoft.AspNetCore.Identity;
using System;

namespace UserProfiles.Domain.Common.Data
{
    public class User : IdentityUser<Guid>
    {
        public string Password { get; set; }
    }
}
