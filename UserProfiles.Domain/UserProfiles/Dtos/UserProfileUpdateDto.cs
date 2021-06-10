using System;

namespace UserProfiles.Domain.UserProfiles.Dtos
{
    public class UserProfileUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
