using System;

namespace UserProfiles.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public int Status { get; set; }
        public string Description { get; set; }

        public BusinessException(int status, string message) : base(message)
        {
            Status = status;
            Description = message;
        }
    }
}
