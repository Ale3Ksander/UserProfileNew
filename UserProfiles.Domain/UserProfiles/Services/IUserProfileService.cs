using System;
using System.Collections.Generic;
using UserProfiles.Domain.UserProfiles.Dtos;

namespace UserProfiles.Domain.UserProfiles.Services
{
    public interface IUserProfileService
    {
        IEnumerable<UserProfile> List();
        UserProfile Get(Guid id);
        UserProfile Create(UserProfileCreateDto model);
        void Update(UserProfileUpdateDto model);
        void Delete(Guid id);
    }
}
