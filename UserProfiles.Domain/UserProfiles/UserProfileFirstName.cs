using CSharpFunctionalExtensions;

namespace UserProfiles.Domain.UserProfiles
{
    public class UserProfileFirstName : ValueObject<UserProfileFirstName>
    {
        public string Value { get; }

        private UserProfileFirstName(string value)
        {
            this.Value = value;
        }

        public static Result<UserProfileFirstName> Create(string userProfileFirstName)
        {
            userProfileFirstName = (userProfileFirstName ?? string.Empty).Trim();

            if (userProfileFirstName.Length == 0)
            {
                return Result.Failure<UserProfileFirstName>("User First Name Should Not Be Empty");
            }

            return Result.Success(new UserProfileFirstName(userProfileFirstName));
        }

        protected override bool EqualsCore(UserProfileFirstName other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(UserProfileFirstName userProfileFirstName)
        {
            return userProfileFirstName.Value;
        }

        public static explicit operator UserProfileFirstName(string userProfileFirstName)
        {
            return Create(userProfileFirstName).Value;
        }
    }
}
