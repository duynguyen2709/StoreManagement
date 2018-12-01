using System;
using System.Windows;

namespace StoreManagement.Utilities
{
    internal class CustomException : Exception
    {
        public CustomException(String _error)
        {
            Error = _error;
        }

        public String Error { get; set; }

        public void showPopupError()
        {
            MessageBox.Show(Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}