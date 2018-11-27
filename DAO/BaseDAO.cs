using StoreManagement.Entities;
using System;
using StoreManagement.Utilities;

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

        public virtual void insert(Object obj)
        {
            instance = GetDAO(obj.GetType());
            instance.insert(obj);
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