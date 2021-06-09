using CSharpFunctionalExtensions;

namespace UserProfiles.Domain.UserProfiles
{
    public class UserProfileEmail : ValueObject<UserProfileEmail>
    {
        public string Value { get; }

        private UserProfileEmail(string value)
        {
            this.Value = value;
        }

        public static Result<UserProfileEmail> Create(string userProfileEmail)
        {
            userProfileEmail = userProfileEmail.Trim();

            if (userProfileEmail.Length > 255)
            {
                return Result.Failure<UserProfileEmail>("User Email Is Too Long");
            }

            return Result.Success(new UserProfileEmail(userProfileEmail));
        }

        protected override bool EqualsCore(UserProfileEmail other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(UserProfileEmail userProfileEmail)
        {
            return userProfileEmail.Value;
        }

        public static explicit operator UserProfileEmail(string userProfileEmail)
        {
            return Create(userProfileEmail).Value;
        }
    }
}
