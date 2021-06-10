namespace UserProfiles.Domain.UserProfiles
{
    public class UserProfile : Common.Entities.Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
