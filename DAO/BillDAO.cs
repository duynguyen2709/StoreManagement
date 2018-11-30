using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class BillDAO : BaseDAO
    {
        public override void delete(Object obj)
        {
            BillEntity entity = obj as BillEntity;

            using (var context = new StoreManagementEntities())
            {
                foreach (KeyValuePair<int, int> product in entity.ListProduct)
                {
                    var detail = (from bill in context.BillDetails
                                  where bill.BillID == entity.BillID
                                     && bill.ProductID == product.Key
                                  select bill)
                        .Single();

                    context.BillDetails.Remove(detail);
                }

                var history = (from bill in context.BillHistories
                               where bill.BillID == entity.BillID
                               select bill)
                    .Single();

                context.BillHistories.Remove(history);
                context.SaveChanges();
            }
        }

        public override Object get(int ID, Type type = null)
        {
            try
            {
                using (var context = new StoreManagementEntities())
                {
                    foreach (var bill in context.BillHistories)
                    {
                        if (bill.BillID == ID)
                        {
                            Dictionary<int, int> lstProduct = new Dictionary<int, int>();

                            foreach (var billDetail in context.BillDetails)
                            {
                                if (billDetail.BillID == ID)
                                {
                                    lstProduct.Add(billDetail.ProductID, billDetail.Quantity);
                                }
                            }

                            Object obj = new
                            {
                                BillInfo = bill,
                                ListProduct = lstProduct
                            };

                            BillEntity entity = convertToEntity(obj) as BillEntity;

                            return entity;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new CustomException(this.GetType() + " : Get Entity");
            }

            return null;
        }

        public override Object getAll(Type type = null)
        {
            List<BillEntity> listBillEntities = new List<BillEntity>();

            using (var context = new StoreManagementEntities())
            {
                foreach (var bill in context.BillHistories)
                {
                    Dictionary<int, int> lstProduct = new Dictionary<int, int>();
                    foreach (var billDetail in context.BillDetails)
                    {
                        if (billDetail.BillID == bill.BillID)
                        {
                            lstProduct.Add(billDetail.ProductID, billDetail.Quantity);
                        }
                    }

                    Object obj = new
                    {
                        BillInfo = bill,
                        ListProduct = lstProduct
                    };

                    BillEntity entity = convertToEntity(obj) as BillEntity;
                    listBillEntities.Add(entity);
                }
            }

            return listBillEntities;
        }

        public override int insert(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Inserting Null Value");

            BillEntity newBill = obj as BillEntity;

            BillHistory billHistory = new BillHistory
            {
                CashierID = newBill.CashierID,
                BillDate = newBill.BillDate,
                TotalPrice = CalculateTotalPrice(newBill.ListProduct)
            };

            using (var context = new StoreManagementEntities())
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

                    context.BillDetails.Add(billDetail);
                }

                context.SaveChanges();
            }

            return billHistory.BillID;
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Converting to Entity Null Value");

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
                ProductEntity entity = dao.get(product.Key) as ProductEntity;
                sum += entity.Price * product.Value;
            }

            return sum;
        }
    }
}