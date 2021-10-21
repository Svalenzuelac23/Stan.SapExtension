using System;

namespace SapExtensions.Exceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException() { }
        public ConnectionException(string errorMessage, int errorCode) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }
}
