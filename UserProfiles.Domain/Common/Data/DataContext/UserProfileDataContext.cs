using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using UserProfiles.Domain.UserProfiles;
using UserProfiles.Domain.UserProfiles.Data;

namespace UserProfiles.Domain.Common.Data.DataContext
{
    public class UserProfileDataContext : IdentityDbContext<User, Role, Guid>
    {
        public UserProfileDataContext(DbContextOptions<UserProfileDataContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserProfileConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
