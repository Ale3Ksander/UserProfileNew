using System;
using System.Collections.Generic;
using System.Text;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;

namespace UserProfiles.Domain.UserProfiles.Data
{
    public interface IUserProfileRepository //: IRepository<UserProfileDataContext, UserProfile>
    {
        IEnumerable<UserProfile> List();
        void Create(UserProfile user);
        void Update(UserProfile user);
        void Delete(Guid id);
    }
}
