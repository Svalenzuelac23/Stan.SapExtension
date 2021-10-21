using System;

namespace SapExtensions.Exceptions
{
    public class TransactionError : Exception
    {
        public TransactionError(string transactionType, string errorMessage, int errorCode)
        {
            TransactionType = transactionType;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public string TransactionType { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }
}
