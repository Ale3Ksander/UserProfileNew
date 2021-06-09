using CSharpFunctionalExtensions;

namespace UserProfiles.Domain.UserProfiles
{
    public class UserProfileLastName : ValueObject<UserProfileLastName>
    {
        public string Value { get; }

        private UserProfileLastName(string value)
        {
            this.Value = value;
        }

        public static Result<UserProfileLastName> Create(string userProfileLastName)
        {
            userProfileLastName = (userProfileLastName ?? string.Empty).Trim();

            if (userProfileLastName.Length == 0)
            {
                return Result.Failure<UserProfileLastName>("User Last Name Should Not Be Empty");
            }

            return Result.Success(new UserProfileLastName(userProfileLastName));
        }

        protected override bool EqualsCore(UserProfileLastName other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(UserProfileLastName userProfileLastName)
        {
            return userProfileLastName.Value;
        }

        public static explicit operator UserProfileLastName(string userProfileLastName)
        {
            return Create(userProfileLastName).Value;
        }
    }
}
