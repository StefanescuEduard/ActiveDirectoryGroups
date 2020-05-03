using System;

namespace ActiveDirectoryRoles.Services
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}