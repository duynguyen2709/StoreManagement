using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class UserDAO : BaseDAO
    {
        public override void delete(Object obj)
        {
            UserEntity user = obj as UserEntity;
            using (var context = new StoreManagementEntities())
            {
                var delete = (from u in context.Users
                              where user.UserID == u.UserID
                              select u).Single();
                context.Users.Remove(delete);
                context.SaveChanges();
            }
        }

        public override Object get(int ID, Type type = null)
        {
            using (var context = new StoreManagementEntities())
            {
                foreach (var user in context.Users)
                {
                    if (user.UserID == ID)
                    {
                        UserEntity userEntity = user.Cast<UserEntity>();
                        return userEntity;
                    }
                }
            }

            return null;
        }

        public override Object getAll(Type type = null)
        {
            List<UserEntity> listUserEntities = new List<UserEntity>();

            using (var context = new StoreManagementEntities())
            {
                foreach (var user in context.Users)
                {
                    UserEntity entity = user.Cast<UserEntity>();
                    listUserEntities.Add(entity);
                }
            }

            return listUserEntities;
        }

        public override int insert(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Inserting Null Value");

            var newUser = obj as UserEntity;
            User user = newUser.Cast<User>();

            using (var context = new StoreManagementEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return user.UserID;
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Converting to Entity Null Value");

            UserEntity entity = obj.Cast<UserEntity>();

            return entity;
        }
    }
}