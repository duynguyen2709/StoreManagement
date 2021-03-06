﻿using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;

namespace StoreManagement.DAO
{
    internal class BaseDAO
    {
        public static BaseDAO getInstance()
        {
            if (instance == null)
            {
                instance = new BaseDAO();
            }

            return instance;
        }

        public virtual void delete(object obj)
        {
            try
            {
                instance = GetDAO(obj.GetType());
                instance.delete(obj);
            }
            catch (CustomException e)
            {
                e.showPopupError();
            }
        }

        public virtual object get(object ID, Type type = null)
        {
            try
            {
                instance = GetDAO(type);
                object obj = instance.get(ID);

                return obj;
            }
            catch (CustomException e)
            {
                e.showPopupError();
            }

            return null;
        }

        public virtual object getAll(Type type = null)
        {
            try
            {
                instance = GetDAO(type);
                object obj = instance.getAll();

                return obj;
            }
            catch (CustomException e)
            {
                e.showPopupError();
            }

            return null;
        }

        public virtual int insert(object obj)
        {
            try
            {
                instance = GetDAO(obj.GetType());

                return instance.insert(obj);
            }
            catch (CustomException e)
            {
                e.showPopupError();
            }

            return -1;
        }

        public virtual void update(object obj)
        {
            try
            {
                instance = GetDAO(obj.GetType());
                instance.update(obj);
            }
            catch (CustomException e)
            {
                e.showPopupError();
            }
        }

        protected static BaseDAO instance;

        protected BaseDAO()
        {
        }

        protected virtual object convertToEntity(object obj)
        {
            return null;
        }

        protected BaseDAO GetDAO(Type type)
        {
            if (type == typeof(UserEntity))
            {
                instance = new UserDAO();
            }
            else if (type == typeof(ProductEntity))
            {
                instance = new ProductDAO();
            }
            else if (type == typeof(BillEntity))
            {
                instance = new BillDAO();
            }
            else if (type == typeof(GoodsImportEntity))
            {
                instance = new GoodsImportDAO();
            }
            else if (type == typeof(UserShiftEntity))
            {
                instance = new ShiftDAO();
            }

            return instance;
        }
    }
}