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

        public virtual Object get(int ID, string className = null)
        {
            instance = GetDAO(className);
            Object obj = instance.get(ID);

            return obj;
        }

        public virtual Object getAll(string className = null)
        {
            instance = GetDAO(className);
            Object obj = instance.getAll();

            return obj;
        }

        public virtual void insert(Object obj)
        {
            instance = GetDAO(obj);
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

        protected BaseDAO GetDAO(Object obj)
        {
            Type type = obj.GetType();

            if (type == typeof(string))
            {
                string className = obj as String;

                switch (className)
                {
                    case "UserEntity":
                        instance = new UserDAO();
                        break;

                    case "ProductEntity":
                        instance = new ProductDAO();
                        break;

                    case "BillEntity":
                        instance = new BillDAO();
                        break;

                    default:
                        throw new CustomException("Illegal Argument Type");
                }
            }
            else if (type == typeof(UserEntity))
                instance = new UserDAO();
            else if (type == typeof(ProductEntity))
                instance = new ProductDAO();
            else if (type == typeof(BillEntity))
                instance = new BillDAO();

            return instance;
        }
    }
}