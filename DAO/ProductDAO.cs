using StoreManagement.Entities;
using System;
using System.Collections.Generic;

namespace StoreManagement.DAO
{
    internal class ProductDAO : BaseDAO
    {
        public override Object get(int ID, string className = null)
        {
            using (var context = new StoreManagementEntities())
            {
                foreach (var product in context.Products)
                {
                    if (product.ProductID == ID)
                    {
                        ProductEntity productEntity = convertToEntity(product) as ProductEntity;
                        return productEntity;
                    }
                }
            }

            return null;
        }

        public override Object getAll(string className = null)
        {
            List<ProductEntity> listProductEntities = new List<ProductEntity>();

            using (var context = new StoreManagementEntities())
            {
                foreach (var product in context.Products)
                {
                    ProductEntity entity = convertToEntity(product) as ProductEntity;
                    listProductEntities.Add(entity);
                }
            }

            return listProductEntities;
        }

        public override void insert(Object obj)
        {
            if (obj == null)
                throw new CustomSQLException(this.GetType() + " : Inserting Null Value");

            var newProduct = obj as Product;

            using (var context = new StoreManagementEntities())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomSQLException(this.GetType() + " : Converting to Entity Null Value");

            Product product = obj as Product;

            ProductEntity entity = new ProductEntity
            {
                ProductID = product.ProductID,
                Brand = product.Brand,
                Type = product.Type,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Quantity = product.Quantity,
            };

            return entity;
        }
    }
}