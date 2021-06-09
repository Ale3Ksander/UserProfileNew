using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;
using UserProfiles.Domain.UserProfiles.Data;

namespace UserProfiles.Domain.UserProfiles.Services
{
    public class UserProfileService : IUserProfileService
    {
        //private readonly UnitOfWork<UserProfileDataContext> _unitOfWork;
        private readonly UserProfileDataContext _dataContext;
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(
            UserProfileDataContext dataContext,
            IUserProfileRepository userProfileRepository)
        {
            _dataContext = dataContext;
            _userProfileRepository = userProfileRepository;
        }
        //public UserProfileService(
        //    UnitOfWork<UserProfileDataContext> unitOfWork,
        //    IUserProfileRepository userProfileRepository)
        //{
        //    _unitOfWork = unitOfWork;
        //    _userProfileRepository = userProfileRepository;
        //}
        public IEnumerable<UserProfile> List()
        {
            var users = _userProfileRepository.List();
            return users.ToList();
        }

        public void Create(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void Update(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
