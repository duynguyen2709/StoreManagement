using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using StoreManagement.Utilities;

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

        public override Object getAll(string className = null)
        {
            List<UserEntity> listUserEntities = new List<UserEntity>();

            using (var context = new StoreManagementEntities())
            {
                foreach (var user in context.Users)
                {
                    UserEntity entity = convertToEntity(user) as UserEntity;
                    listUserEntities.Add(entity);
                }
            }

            return listUserEntities;
        }

        public override void insert(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Inserting Null Value");

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
                throw new CustomException(this.GetType() + " : Converting to Entity Null Value");

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