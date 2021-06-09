using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfiles.Domain.UserProfiles.Services
{
    public interface IUserProfileService
    {
        IEnumerable<UserProfile> List();
        void Create(UserProfile user);
        void Update(UserProfile user);
        void Delete(Guid id);
    }
}
