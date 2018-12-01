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
            try
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
            catch (Exception e)
            {
                throw new CustomException(this.GetType().Name + " : Delete " + obj.ToString() + "\n" + e.Message);
            }
        }

        public override Object get(int ID, Type type = null)
        {
            UserEntity userEntity = null;

            try
            {
                using (var context = new StoreManagementEntities())
                {
                    userEntity = context.Users.Find(ID).Cast<UserEntity>();
                }
            }
            catch (Exception e)
            {
                throw new CustomException(this.GetType().Name + " : Get " + ID + "\n" + e.Message);
            }

            return userEntity;
        }

        public override Object getAll(Type type = null)
        {
            List<UserEntity> listUserEntities = new List<UserEntity>();

            try
            {
                using (var context = new StoreManagementEntities())
                {
                    foreach (var user in context.Users)
                    {
                        UserEntity entity = user.Cast<UserEntity>();
                        listUserEntities.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                throw new CustomException(this.GetType().Name + " : GetAll \n" + e.Message);
            }

            return listUserEntities;
        }

        public override int insert(Object obj)
        {
            try
            {
                var newUser = obj as UserEntity;
                User user = newUser.Cast<User>();

                using (var context = new StoreManagementEntities())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }

                return user.UserID;
            }
            catch (Exception e)
            {
                throw new CustomException(this.GetType().Name + " : Insert " + obj.ToString() + "\n" + e.Message);
            }
        }

        public override void update(Object obj)
        {
            try
            {
                UserEntity user = obj as UserEntity;

                using (var context = new StoreManagementEntities())
                {
                    var oldUser = context.Users.Find(user.UserID);
                    context.Entry(oldUser).CurrentValues.SetValues(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new CustomException(this.GetType().Name + " : Update " + obj.ToString() + "\n" + e.Message);
            }
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType().Name + " : Converting to Entity Null Value");

            UserEntity entity = obj.Cast<UserEntity>();

            return entity;
        }
    }
}