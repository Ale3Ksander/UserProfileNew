using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using UserProfiles.Domain.Common.Entities;

namespace UserProfiles.Domain.UserProfiles
{
    public class UserProfile : Common.Entities.Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //public /*private*/ UserProfile(
        //    UserProfileFirstName firstName,
        //    UserProfileLastName lastName,
        //    UserProfileAge age,
        //    UserProfilePhoneNumber phoneNumber,
        //    UserProfileEmail email)
        //{
        //    FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        //    LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        //    Age = age ?? throw new ArgumentNullException(nameof(age));
        //    PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        //    Email = email ?? throw new ArgumentNullException(nameof(email));
        //    CreatedAt = DateTime.UtcNow;
        //}

        //public static Result<UserProfile> Create()
    }
}
