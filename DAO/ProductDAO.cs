using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class ProductDAO : BaseDAO
    {
        public override void delete(Object obj)
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

        public override Object get(int ID, Type type = null)
        {
            using (var context = new StoreManagementEntities())
            {
                foreach (var product in context.Products)
                {
                    if (product.ProductID == ID)
                    {
                        ProductEntity productEntity = product.Cast<ProductEntity>();
                        return productEntity;
                    }
                }
            }

            return null;
        }

        public override Object getAll(Type type = null)
        {
            List<ProductEntity> listProductEntities = new List<ProductEntity>();

            using (var context = new StoreManagementEntities())
            {
                foreach (var product in context.Products)
                {
                    ProductEntity entity = product.Cast<ProductEntity>();
                    listProductEntities.Add(entity);
                }
            }

            return listProductEntities;
        }

        public override int insert(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Inserting Null Value");

            var product = obj.Cast<Product>();

            using (var context = new StoreManagementEntities())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

            return product.ProductID;
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