using StoreManagement.Entities;
using System;

namespace StoreManagement.DAO
{
    internal class UserDAO : BaseDAO
    {
        public override Object get(int ID, string className = null)
        {
            using (var context = new StoreManagementEntities())
            {
                foreach (var user in context.Users)
                {
                    if (user.UserID == ID)
                    {
                        UserEntity userEntity = convertToEntity(user) as UserEntity;
                        return userEntity;
                    }
                }
            }

            return null;
        }

        public override void insert(Object obj)
        {
            if (obj == null)
                throw new CustomSQLException(this.GetType() + " : Inserting Null Value");

            var newUser = obj as User;

            using (var context = new StoreManagementEntities())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomSQLException(this.GetType() + " : Converting to Entity Null Value");

            User user = obj as User;

            UserEntity entity = new UserEntity
            {
                Username = user.Username,
                UserID = user.UserID,
                Address = user.Address,
                Birthdate = user.Birthdate,
                FullName = user.FullName,
                IDCardNumber = user.IDCardNumber,
                Password = user.Password,
                Role = user.Role
            };

            return entity;
        }
    }
}