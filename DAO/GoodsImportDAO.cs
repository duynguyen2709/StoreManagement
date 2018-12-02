using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class GoodsImportDAO : BaseDAO
    {
        public override void delete(Object obj)
        {
            try
            {
                GoodsImportEntity entity = obj as GoodsImportEntity;

                using (var context = new StoreManagementEntities())
                {
                    var delete = (from u in context.GoodsImportHistories
                                  where entity.ImportDate == u.ImportDate
                                  select u).Single();

                    context.GoodsImportHistories.Remove(delete);

                    var product = context.Products.Find(entity.ProductID);
                    product.Quantity += entity.Quantity;

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : Delete " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }
        }

        public override object get(object ID, Type type = null)
        {
            GoodsImportEntity entity = null;

            try
            {
                DateTime ImportDate = (DateTime)ID?.GetType().GetProperty("ImportDate")?.GetValue(ID, null);
                int ProductID = (int)ID?.GetType().GetProperty("ProductID")?.GetValue(ID, null);

                using (var context = new StoreManagementEntities())
                {
                    entity = context.GoodsImportHistories.Find(ImportDate, ProductID).Cast<GoodsImportEntity>();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : Get " + ID + "\n" + e.Message);
                ex.showPopupError();
            }

            return entity;
        }

        public override Object getAll(Type type = null)
        {
            List<GoodsImportEntity> listGoodsImportEntities = new List<GoodsImportEntity>();

            try
            {
                using (var context = new StoreManagementEntities())
                {
                    foreach (var obj in context.GoodsImportHistories)
                    {
                        GoodsImportEntity entity = obj.Cast<GoodsImportEntity>();
                        listGoodsImportEntities.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : GetAll \n" + e.Message);
                ex.showPopupError();
            }

            return listGoodsImportEntities;
        }

        public override int insert(Object obj)
        {
            try
            {
                var newEntity = obj as GoodsImportEntity;
                GoodsImportHistory entity = newEntity.Cast<GoodsImportHistory>();

                using (var context = new StoreManagementEntities())
                {
                    context.GoodsImportHistories.Add(entity);
                    var product = context.Products.Find(entity.ProductID);
                    product.Quantity += entity.Quantity;
                    context.SaveChanges();
                }

                return (int)entity.ImportDate.ToBinary();
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : Insert " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }

            return -1;
        }

        public override void update(Object obj)
        {
            try
            {
                GoodsImportEntity entity = obj as GoodsImportEntity;

                using (var context = new StoreManagementEntities())
                {
                    var old = context.GoodsImportHistories.Find(entity.ImportDate, entity.ProductID);
                    var oldQuantity = old.Quantity;

                    context.Entry(old).CurrentValues.SetValues(entity);

                    var product = context.Products.Find(entity.ProductID);
                    product.Quantity = product.Quantity - oldQuantity + entity.Quantity;

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : Update " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType().Name + " : Converting to Entity Null Value");

            GoodsImportEntity entity = obj.Cast<GoodsImportEntity>();

            return entity;
        }
    }
}