using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;

namespace UserProfiles.Domain.UserProfiles.Data
{
    public class UserProfileRepository : Repository<UserProfileDataContext, UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(UnitOfWork<UserProfileDataContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
