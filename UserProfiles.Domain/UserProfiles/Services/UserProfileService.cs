using System;
using System.Collections.Generic;
using System.Linq;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;
using UserProfiles.Domain.Exceptions;
using UserProfiles.Domain.UserProfiles.Data;
using UserProfiles.Domain.UserProfiles.Dtos;

namespace UserProfiles.Domain.UserProfiles.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UnitOfWork<UserProfileDataContext> _unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(
            UnitOfWork<UserProfileDataContext> unitOfWork,
            IUserProfileRepository userProfileRepository)
        {
            _unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }

        public IEnumerable<UserProfile> List()
        {
            var users = _unitOfWork.Query<UserProfile>();
            return users;
        }

        public UserProfile Get(Guid id)
        {
            var user = _unitOfWork.Query<UserProfile>().FirstOrDefault(x => x.Id == id);

            return user;
        }

        public UserProfile Create(UserProfileCreateDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var userExists = _unitOfWork.Query<UserProfile>().Any(x => x.FirstName == model.FirstName
                                                                    && x.LastName == model.LastName);
            if (userExists)
                throw new BusinessException(-1, "User Name And Last Name Should Be Unique");

            var newUser = new UserProfile()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedAt = DateTime.UtcNow
            };

            _userProfileRepository.Create(newUser);
            return newUser;
        }

        public void Update(UserProfileUpdateDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var userFromStore = _unitOfWork.Query<UserProfile>().FirstOrDefault(x => x.Id == model.Id);
            if (userFromStore != null)
            {
                var userExists = _unitOfWork.Query<UserProfile>().Any(x => x.FirstName == model.FirstName
                                                                && x.LastName == model.LastName);
                if (userExists)
                    throw new BusinessException(-1, "User Name And Last Name Should Be Unique");

                userFromStore.FirstName = model.FirstName;
                userFromStore.LastName = model.LastName;
                userFromStore.Age = model.Age;
                userFromStore.PhoneNumber = model.PhoneNumber;
                userFromStore.Email = model.Email;
                userFromStore.UpdatedAt = DateTime.UtcNow;
            }
        }

        public void Delete(Guid id)
        {
            var userFromStore = _unitOfWork.Query<UserProfile>().FirstOrDefault(x => x.Id == id);
            if (userFromStore == null)
                throw new BusinessException(-1, "User Not Found");

            _userProfileRepository.Delete(userFromStore);
        }
    }
}
