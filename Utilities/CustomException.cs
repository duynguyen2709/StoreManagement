using System;

namespace StoreManagement.Utilities
{
    internal class CustomException : Exception
    {
        public CustomException(String _error)
        {
            Error = _error;
        }

        public String Error { get; set; }
    }
}