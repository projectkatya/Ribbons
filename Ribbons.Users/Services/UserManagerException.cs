using System;

namespace Ribbons.Users.Services
{
    public sealed class UserManagerException : Exception
    {
        public UserManagerOperation Operation { get; internal set; }
        public UserManagerErrorCode ErrorCode { get; internal set; }

        public UserManagerException() : base() { }
        public UserManagerException(string message) : base(message) { }
    }
}