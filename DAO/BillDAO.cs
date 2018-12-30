using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class BillDAO : BaseDAO
    {
        public override void delete(object obj)
        {
            try
            {
                BillEntity entity = obj as BillEntity;

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    foreach (KeyValuePair<int, int> product in entity.ListProduct)
                    {
                        BillDetail detail = (from bill in context.BillDetails
                                             where bill.BillID == entity.BillID
                                                && bill.ProductID == product.Key
                                             select bill)
                            .Single();

                        context.BillDetails.Remove(detail);

                        Product pro = context.Products.Find(product.Key);
                        pro.Quantity += product.Value;
                    }

                    BillHistory history = (from bill in context.BillHistories
                                           where bill.BillID == entity.BillID
                                           select bill)
                        .Single();

                    context.BillHistories.Remove(history);
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
            try
            {
                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    BillHistory bill = context.BillHistories.Find(ID);
                    if (bill == null)
                    {
                        throw new Exception();
                    }

                    Dictionary<int, int> lstProduct = context.BillDetails.AsParallel()
                                            .Where(temp => temp.BillID == bill.BillID)
                                            .ToDictionary(t => t.ProductID, t => t.Quantity);

                    BillEntity entity = new BillEntity()
                    {
                        BillDate = bill.BillDate,
                        BillID = bill.BillID,
                        CashierID = bill.CashierID,
                        ListProduct = lstProduct,
                        TotalPrice = bill.TotalPrice
                    };

                    return entity;
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : Get " + ID + "\n" + e.Message);
                ex.showPopupError();
            }

            return null;
        }

        public override object getAll(Type type = null)
        {
            List<BillEntity> listBillEntities = new List<BillEntity>();

            try
            {
                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    foreach (BillHistory bill in context.BillHistories)
                    {
                        Dictionary<int, int> lstProduct = context.BillDetails.AsParallel()
                                                .Where(temp => temp.BillID == bill.BillID)
                                                .ToDictionary(t => t.ProductID, t => t.Quantity);

                        BillEntity entity = new BillEntity()
                        {
                            BillDate = bill.BillDate,
                            BillID = bill.BillID,
                            CashierID = bill.CashierID,
                            ListProduct = lstProduct,
                            TotalPrice = bill.TotalPrice
                        };

                        listBillEntities.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(GetType().Name + " : GetAll \n" + e.Message);
                ex.showPopupError();
            }

            return listBillEntities;
        }

        public override int insert(object obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new CustomException(GetType().Name + " : Inserting Null Value");
                }

                BillEntity newBill = obj as BillEntity;

                BillHistory billHistory = new BillHistory
                {
                    CashierID = newBill.CashierID,
                    BillDate = newBill.BillDate,
                    TotalPrice = CalculateTotalPrice(newBill.ListProduct)
                };

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    context.BillHistories.Add(billHistory);

                    foreach (KeyValuePair<int, int> product in newBill.ListProduct)
                    {
                        BillDetail billDetail = new BillDetail
                        {
                            BillID = billHistory.BillID,
                            ProductID = product.Key,
                            Quantity = product.Value
                        };

                        Product pro = context.Products.Find(product.Key);
                        pro.Quantity -= product.Value;

                        context.BillDetails.Add(billDetail);
                    }

                    context.SaveChanges();
                }

                return billHistory.BillID;
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
                BillEntity entity = obj as BillEntity;

                using (StoreManagementEntities context = new StoreManagementEntities())
                {
                    BillHistory billHistory = context.BillHistories.Find(entity.BillID);
                    context.Entry(billHistory).CurrentValues.SetValues(entity);
                    billHistory.TotalPrice = CalculateTotalPrice(entity.ListProduct);

                    Dictionary<int, int> listProduct = entity.ListProduct;

                    foreach (KeyValuePair<int, int> product in listProduct)
                    {
                        BillDetail billDetail = context.BillDetails.Find(entity.BillID, product.Key);

                        if (billDetail != null && billDetail.Quantity != product.Value)
                        {
                            Product pro = context.Products.Find(product.Key);
                            pro.Quantity = pro.Quantity + billDetail.Quantity - product.Value;

                            context.Entry(billDetail)
                                   .CurrentValues.SetValues(new
                                   {
                                       BillID = billDetail.BillID,
                                       ProductID = product.Key,
                                       Quantity = product.Value
                                   });
                        }
                        else if (billDetail == null)
                        {
                            Product pro = context.Products.Find(product.Key);
                            pro.Quantity = pro.Quantity - product.Value;

                            BillDetail detail = new BillDetail()
                            {
                                BillID = entity.BillID,
                                ProductID = product.Key,
                                Quantity = product.Value
                            };

                            context.BillDetails.Add(detail);
                        }
                    }

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

            Dictionary<int, int> listProduct =
                obj?.GetType().GetProperty("ListProduct")?.GetValue(obj, null) as Dictionary<int, int>;
            BillHistory billInfo = obj?.GetType().GetProperty("BillInfo")?.GetValue(obj, null) as BillHistory;

            BillEntity entity = new BillEntity()
            {
                BillID = billInfo.BillID,
                CashierID = billInfo.CashierID,
                BillDate = billInfo.BillDate,
                ListProduct = listProduct,
                TotalPrice = CalculateTotalPrice(listProduct)
            };

            return entity;
        }

        private long CalculateTotalPrice(Dictionary<int, int> listProduct)
        {
            long sum = 0;
            ProductDAO dao = new ProductDAO();

            foreach (KeyValuePair<int, int> product in listProduct)
            {
                if (dao.get(product.Key) is ProductEntity entity)
                {
                    sum += entity.Price * product.Value;
                }
            }

            return sum;
        }
    }
}