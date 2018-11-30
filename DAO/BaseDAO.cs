﻿using StoreManagement.Entities;
using System;

namespace StoreManagement.DAO
{
    internal class BaseDAO
    {
        public static BaseDAO getInstance()
        {
            if (instance == null)
                instance = new BaseDAO();

            return instance;
        }

        public virtual void delete(Object obj)
        {
            instance = GetDAO(obj.GetType());
            instance.delete(obj);
        }

        public virtual Object get(int ID, Type type = null)
        {
            instance = GetDAO(type);
            Object obj = instance.get(ID);

            return obj;
        }

        public virtual Object getAll(Type type = null)
        {
            instance = GetDAO(type);
            Object obj = instance.getAll();

            return obj;
        }

        public virtual int insert(Object obj)
        {
            instance = GetDAO(obj.GetType());
            return instance.insert(obj);
        }

        public virtual void update(Object obj)
        {
            instance = GetDAO(obj.GetType());
            instance.update(obj);
        }

        protected static BaseDAO instance;

        protected BaseDAO()
        {
        }

        protected virtual Object convertToEntity(Object obj)
        {
            return null;
        }

        protected BaseDAO GetDAO(Type type)
        {
            if (type == typeof(UserEntity))
                instance = new UserDAO();
            else if (type == typeof(ProductEntity))
                instance = new ProductDAO();
            else if (type == typeof(BillEntity))
                instance = new BillDAO();

            return instance;
        }
    }
}