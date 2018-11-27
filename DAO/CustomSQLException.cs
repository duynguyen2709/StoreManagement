using System;

namespace StoreManagement.DAO
{
    internal class CustomSQLException : Exception
    {
        public CustomSQLException(String _error)
        {
            Error = _error;
        }

        public String Error { get; set; }
    }
}