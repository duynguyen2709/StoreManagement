using System;

namespace StoreManagement.Entities
{
    internal class UserEntity
    {
        public UserEntity()
        {
            Address = FullName = Password = IDCardNumber = Username = "NULL";
            Birthdate = DateTime.Today;
            Role = UserID = 0;
        }

        public string Address { get; set; }

        public System.DateTime Birthdate { get; set; }

        public string FullName { get; set; }

        public string IDCardNumber { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public int UserID { get; set; }

        public string Username { get; set; }
    }
}