using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;

namespace UserProfiles.Domain.UserProfiles.Data
{
    public class UserProfileRepository : IUserProfileRepository//: Repository<UserProfileDataContext, UserProfile>, IUserProfileRepository
    {
        //public UserProfileRepository(UnitOfWork<UserProfileDataContext> unitOfWork) : base(unitOfWork)
        //{
        //}
        private readonly UserProfileDataContext _context;

        public UserProfileRepository(UserProfileDataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserProfile> List()
        {
            return _context.UserProfiles;
        }

        public void Create(UserProfile user)
        {
            _context.UserProfiles.Add(user);
            _context.SaveChanges();
        }

        public void Update(UserProfile user)
        {
            _context.UserProfiles.AsNoTracking();
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            UserProfile user = _context.UserProfiles.Find(id);
            if (user != null)
                _context.UserProfiles.Remove(user);
            _context.SaveChanges();
        }
    }
}
