using CSharpFunctionalExtensions;

namespace UserProfiles.Domain.UserProfiles
{
    public class UserProfileAge : ValueObject<UserProfileAge>
    {
        public short Value { get; }

        private UserProfileAge(short value)
        {
            this.Value = value;
        }

        public static Result<UserProfileAge> Create(short userProfileAge)
        {
            if (userProfileAge <= 0)
            {
                return Result.Failure<UserProfileAge>("User Age Should Not Be Less Then Zero Or Equal To Zero");
            }
            return Result.Success(new UserProfileAge(userProfileAge));
        }

        protected override bool EqualsCore(UserProfileAge other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator short(UserProfileAge userProfileAge)
        {
            return userProfileAge.Value;
        }

        public static explicit operator UserProfileAge(short userProfileAge)
        {
            return Create(userProfileAge).Value;
        }
    }
}
