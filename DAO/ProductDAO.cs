using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class ProductDAO : BaseDAO
    {
        public override void delete(Object obj)
        {
            try
            {
                ProductEntity product = obj as ProductEntity;

                using (var context = new StoreManagementEntities())
                {
                    var delete = (from p in context.Products
                                  where product.ProductID == p.ProductID
                                  select p).Single();

                    context.Products.Remove(delete);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : Delete " + obj.ToString();

                throw new CustomException(msg);
            }
        }

        public override Object get(int ID, Type type = null)
        {
            ProductEntity productEntity = null;
            try
            {
                using (var context = new StoreManagementEntities())
                {
                    productEntity = context.Products.Find(ID).Cast<ProductEntity>();
                }
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : get " + ID;

                throw new CustomException(msg);
            }

            return productEntity;
        }

        public override Object getAll(Type type = null)
        {
            List<ProductEntity> listProductEntities = new List<ProductEntity>();

            try
            {
                using (var context = new StoreManagementEntities())
                {
                    foreach (var product in context.Products)
                    {
                        ProductEntity entity = product.Cast<ProductEntity>();
                        listProductEntities.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : GetAll ";

                throw new CustomException(msg);
            }

            return listProductEntities;
        }

        public override int insert(Object obj)
        {
            try
            {
                var product = obj.Cast<Product>();

                using (var context = new StoreManagementEntities())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

                return product.ProductID;
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : Update " + obj.ToString();

                throw new CustomException(msg);
            }
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Converting to Entity Null Value");

            ProductEntity entity = obj.Cast<ProductEntity>();

            return entity;
        }
    }
}