using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UserProfiles.Domain.Common.Data;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;
using UserProfiles.Domain.Exceptions;
using UserProfiles.Domain.UserProfiles.Data;
using UserProfiles.Domain.UserProfiles.Dtos;

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
            var users = UserProfileDataStore.Current.UserProfiles;
            return users;
        }

        public UserProfile Get(int id)
        {
            var user = UserProfileDataStore.Current.UserProfiles.FirstOrDefault(x => x.Id == id);

            return user;
        }

        public UserProfile Create(UserProfileCreateDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var userExists = UserProfileDataStore.Current.UserProfiles.Any(x => x.FirstName == model.FirstName
                                                                                        && x.LastName == model.LastName);
            if (userExists)
                throw new BusinessException(-1, "User Name And Last Name Should Be Unique");

            var maxUserId = UserProfileDataStore.Current.UserProfiles.Max(x => x.Id);
            var newUser = new UserProfile()
            {
                Id = ++maxUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedAt = DateTime.UtcNow
            };

            UserProfileDataStore.Current.UserProfiles.Add(newUser);
            return newUser;
        }

        public void Update(UserProfileUpdateDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var userFromStore = UserProfileDataStore.Current.UserProfiles.FirstOrDefault(x =>x.Id == model.Id);
            if (userFromStore != null)
            {
                var userExists = UserProfileDataStore.Current.UserProfiles.Any(x => x.FirstName == model.FirstName
                                                                                        && x.LastName == model.LastName);
                if(userExists)
                    throw new BusinessException(-1, "User Name And Last Name Should Be Unique");

                userFromStore.Id = model.Id;
                userFromStore.FirstName = model.FirstName;
                userFromStore.LastName = model.LastName;
                userFromStore.Age = model.Age;
                userFromStore.PhoneNumber = model.PhoneNumber;
                userFromStore.Email = model.Email;
                userFromStore.UpdatedAt = DateTime.UtcNow;
            }
        }

        public void Delete(int id)
        {
            var userFromStore = UserProfileDataStore.Current.UserProfiles.FirstOrDefault(x => x.Id == id);
            if (userFromStore == null)
                throw new BusinessException(-1, "User Not Found");

            UserProfileDataStore.Current.UserProfiles.Remove(userFromStore);
        }
    }
}
