using CSharpFunctionalExtensions;

namespace UserProfiles.Domain.UserProfiles
{
    public class UserProfilePhoneNumber : ValueObject<UserProfilePhoneNumber>
    {
        public string Value { get; }

        private UserProfilePhoneNumber(string value)
        {
            this.Value = value;
        }

        public static Result<UserProfilePhoneNumber> Create(string userProfilePhoneNumber)
        {
            userProfilePhoneNumber = (userProfilePhoneNumber ?? string.Empty).Trim();

            return Result.Success(new UserProfilePhoneNumber(userProfilePhoneNumber));
        }

        protected override bool EqualsCore(UserProfilePhoneNumber other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(UserProfilePhoneNumber userProfilePhoneNumber)
        {
            return userProfilePhoneNumber.Value;
        }

        public static explicit operator UserProfilePhoneNumber(string userProfilePhoneNumber)
        {
            return Create(userProfilePhoneNumber).Value;
        }
    }
}
