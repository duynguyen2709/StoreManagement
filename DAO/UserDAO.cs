using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class UserDAO : BaseDAO
    {
        public override void delete(object obj)
        {
            try
            {
                UserEntity user = obj as UserEntity;

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    User delete = (from u in context.Users
                                   where user.UserID == u.UserID
                                   select u).Single();

                    context.Users.Remove(delete);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : Delete " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }
        }

        public override object get(object ID, Type type = null)
        {
            UserEntity userEntity = null;

            try
            {
                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    userEntity = context.Users.Find(ID).Cast<UserEntity>();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : Get " + ID + "\n" + e.Message);
                ex.showPopupError();
            }

            return userEntity;
        }

        public override object getAll(Type type = null)
        {
            List<UserEntity> listUserEntities = new List<UserEntity>();

            try
            {
                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    foreach (User user in context.Users)
                    {
                        UserEntity entity = user.Cast<UserEntity>();
                        listUserEntities.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : GetAll \n" + e.Message);
                ex.showPopupError();
            }

            return listUserEntities;
        }

        public override int insert(object obj)
        {
            try
            {
                UserEntity newUser = obj as UserEntity;
                User user = newUser.Cast<User>();

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }

                return user.UserID;
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : Insert " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }

            return -1;
        }

        public override void update(object obj)
        {
            try
            {
                UserEntity user = obj as UserEntity;

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    User oldUser = context.Users.Find(user.UserID);
                    context.Entry(oldUser).CurrentValues.SetValues(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : Update " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }
        }

        protected override object convertToEntity(object obj)
        {
            if (obj == null)
            {
                throw new CustomException(GetType().Name + " : Converting to Entity Null Value");
            }

            UserEntity entity = obj.Cast<UserEntity>();

            return entity;
        }
    }
}