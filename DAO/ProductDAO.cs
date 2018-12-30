using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class ProductDAO : BaseDAO
    {
        public override void delete(object obj)
        {
            try
            {
                ProductEntity product = obj as ProductEntity;

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    Product delete = (from p in context.Products
                                      where product.ProductID == p.ProductID
                                      select p).Single();

                    context.Products.Remove(delete);
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
            ProductEntity productEntity = null;
            try
            {
                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    productEntity = context.Products.Find(ID).Cast<ProductEntity>();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : Get " + ID + "\n" + e.Message);
                ex.showPopupError();
            }

            return productEntity;
        }

        public override object getAll(Type type = null)
        {
            List<ProductEntity> listProductEntities = new List<ProductEntity>();

            try
            {
                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    foreach (Product product in context.Products)
                    {
                        ProductEntity entity = product.Cast<ProductEntity>();
                        listProductEntities.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : GetAll \n" + e.Message);
                ex.showPopupError();
            }

            return listProductEntities;
        }

        public override int insert(object obj)
        {
            try
            {
                Product product = obj.Cast<Product>();

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

                return product.ProductID;
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
                ProductEntity product = obj as ProductEntity;

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    Product oldProduct = context.Products.Find(product.ProductID);
                    context.Entry(oldProduct).CurrentValues.SetValues(product);
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

            ProductEntity entity = obj.Cast<ProductEntity>();

            return entity;
        }
    }
}