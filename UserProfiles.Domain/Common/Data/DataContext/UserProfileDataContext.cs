using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using UserProfiles.Domain.UserProfiles;
using UserProfiles.Domain.UserProfiles.Data;

namespace UserProfiles.Domain.Common.Data.DataContext
{
    public class UserProfileDataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public UserProfileDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public UserProfileDataContext(DbContextOptions<UserProfileDataContext> options) : base(options)
        //{

        //}

        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserProfileConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
