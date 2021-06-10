using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UserProfiles.Domain.Common.Data;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Common.Data.Enums;

namespace UserProfiles.Domain.Common.Initializers
{
    public class ProfileDatabaseInitializer : IDatabaseInitializer
    {
        private readonly UserProfileDataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public ProfileDatabaseInitializer(
            DbContextOptions<UserProfileDataContext> options,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _dataContext = new UserProfileDataContext(options);
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (!_dataContext.Roles.Any())
            {
                var result = _roleManager.CreateAsync(new Role { Name = ApplicationRole.Admin }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }

            if (!_dataContext.UserProfiles.Any())
            {
                var user = new User
                {
                    UserName = "Admin"
                };

                var createUserResult = _userManager.CreateAsync(user, "Password111").Result;
                if (!createUserResult.Succeeded)
                {
                    throw new Exception(createUserResult.Errors.First().Description);
                }
            }
        }
    }
}
