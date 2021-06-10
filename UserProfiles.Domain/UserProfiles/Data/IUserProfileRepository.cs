using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;

namespace UserProfiles.Domain.UserProfiles.Data
{
    public interface IUserProfileRepository : IRepository<UserProfileDataContext, UserProfile>
    {
    }
}
