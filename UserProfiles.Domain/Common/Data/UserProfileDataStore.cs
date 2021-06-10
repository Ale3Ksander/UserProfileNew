using System.Collections.Generic;
using UserProfiles.Domain.UserProfiles;


namespace UserProfiles.Domain.Common.Data
{
    public class UserProfileDataStore
    {
        public static UserProfileDataStore Current { get; } = new UserProfileDataStore(); 
        public List<UserProfile> UserProfiles { get; set; }

        public UserProfileDataStore()
        {
            UserProfiles = new List<UserProfile>()
            {
                new UserProfile()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Trump",
                    Age = 41,
                    PhoneNumber = "25 25 258",
                    Email = "john@mail.com"
                },

                new UserProfile()
                {
                    Id = 2,
                    FirstName = "Poul",
                    LastName = "Trip",
                    Age = 20,
                    PhoneNumber = "68 98 158",
                    Email = "poul@mail.com"
                },

                new UserProfile()
                {
                    Id = 3, 
                    FirstName = "Kevin",
                    LastName = "Fort",
                    Age = 50,
                    PhoneNumber = "78 75 123",
                    Email = "fort@mail.com"
                }
            };
        }
    }
}
